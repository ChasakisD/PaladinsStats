using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using PaladinsAPI;
using PaladinsAPI.Enumerations;
using PaladinsAPI.Exceptions;
using PaladinsAPI.Models;
using PaladinsStats.Model;
using PaladinsStats.Service.Models;

namespace PaladinsStats.Service.Controllers
{
    public class PlayersController : ApiController
    {
        private readonly PaladinsStatsServiceContext _dbContext = new PaladinsStatsServiceContext();
        private readonly LoadoutItemEntitiesController _loadoutItemController = new LoadoutItemEntitiesController();
        private readonly PlayerAchievementsController _achievementsController = new PlayerAchievementsController();
        private readonly PlayerStatusEntitiesController _statusController = new PlayerStatusEntitiesController();
        private readonly PlayerChampionRankEntitiesController _championRanksController = new PlayerChampionRankEntitiesController();
        private readonly PlayerLoadoutsEntitiesController _playerLoadoutsController = new PlayerLoadoutsEntitiesController();
        private readonly PaladinsApi _paladinsApi = new PaladinsApi(Constants.PaladinsDevId, Constants.PaladinsAuthKey, Platform.Pc);
        
        [Route("api/Players")]
        public IQueryable<PlayerEntity> GetPlayerEntities()
        {
            return _dbContext.PlayerEntities;
        }

        [Route("api/Player/{id}")]
        [ResponseType(typeof(PlayerEntity))]
        public IHttpActionResult GetPlayerEntity(string id)
        {
            var identity = int.TryParse(id, out var playerId);
            PlayerEntity player;
            if (identity)
            {
                player = _dbContext.PlayerEntities
                    .FirstOrDefault(p => p.Id == playerId);

                if (player == null) return NotFound();
            }
            else
            {
                player = _dbContext.PlayerEntities
                    .FirstOrDefault(p => p.Name.Equals(id));

                if (player == null) return NotFound();
            }

            return Ok(player);
        }

        [HttpPost]
        [Route("api/Player/{id}/update")]
        [ResponseType(typeof(PlayerEntity))]
        public async Task<IHttpActionResult> RetrievePlayerFromApi(string id)
        {
            var player = _dbContext.PlayerEntities.FirstOrDefault(p => p.Name.Equals(id)) 
                ?? new PlayerEntity{lastUpdated = DateTime.UtcNow.AddHours(-1)};
            if (!(DateTime.UtcNow.Subtract(player.lastUpdated).TotalMinutes > 30))
            {
                /* Return 417 in order the client understand that the player did not updated */
                return StatusCode(HttpStatusCode.ExpectationFailed);
            }

            var isPlayerInDb = player.Name != null;

            try
            {
                #region Update Player

                var playerFromApi = await _paladinsApi.GetPlayer(id);
                var newplayer = new PlayerEntity(playerFromApi)
                {
                    DbId = player.DbId,
                    Champions_Last_Updated = DateTime.Now,
                    History_Last_Updated = DateTime.Now,
                    lastUpdated = DateTime.Now
                };
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<PlayerEntity, PlayerEntity>();
                    cfg.CreateMap<PlayerAchievementsEntity, PlayerAchievementsEntity>();
                    cfg.CreateMap<PlayerChampionRankEntity, PlayerChampionRankEntity>();
                    cfg.CreateMap<PlayerStatusEntity, PlayerStatusEntity>();
                    cfg.CreateMap<PlayerLoadoutsEntity, PlayerLoadoutsEntity>();
                });
                Mapper.Map(newplayer, player);

                if (isPlayerInDb) PutPlayerEntity(player.DbId, player);
                else PostPlayerEntity(player);

                #endregion

                #region Update Achievements

                if (isPlayerInDb)
                {
                    var achievements = _dbContext.PlayerAchievementsEntities
                        .FirstOrDefault(a => a.Id == newplayer.Id);

                    if (achievements == null) return BadRequest();

                    var achievementsFromApi = await _paladinsApi.GetPlayerAchievements(newplayer.Id);
                    var newAchievements = new PlayerAchievementsEntity(achievementsFromApi)
                    {
                        DbId = achievements.DbId
                    };
                    Mapper.Map(newAchievements, achievements);
                    _achievementsController.PutPlayerAchievementsEntity(achievements.DbId, achievements);
                }
                else
                {
                    var achievementsFromApi = await _paladinsApi.GetPlayerAchievements(newplayer.Id);
                    _achievementsController.PostPlayerAchievementsEntity(new PlayerAchievementsEntity(achievementsFromApi));
                }

                #endregion

                #region Update ChampionRanks
                
                var ranks = _dbContext.PlayerChampionRankEntities
                    .Where(r => r.player_id.Equals(newplayer.Id.ToString()));

                var ranksFromApi = await _paladinsApi.GetChampionRanks(newplayer.Id);
                if (ranks.Any())
                {
                    foreach (var rank in ranks)
                    {
                        var foundRank = ranksFromApi
                            .Find(r => r.champion_id.Equals(rank.champion_id));
                        var selectedRank = new PlayerChampionRankEntity(foundRank)
                        {
                            DbId = rank.DbId
                        };
                        Mapper.Map(selectedRank, rank);
                        _championRanksController.PutPlayerChampionRankEntity(rank.DbId, rank);
                        ranksFromApi.Remove(foundRank);
                    }
                }

                foreach (var rankEntity in ranksFromApi)
                {
                    var selectedRank = new PlayerChampionRankEntity(rankEntity);
                    _championRanksController.PostPlayerChampionRankEntity(selectedRank);
                }

                #endregion

                #region Update Player Status

                if (isPlayerInDb)
                {
                    var status = _dbContext.PlayerStatusEntities
                        .FirstOrDefault(s => s.playerId == newplayer.Id);

                    if (status == null) return BadRequest();

                    var statusFromApi = await _paladinsApi.GetPlayerStatus(newplayer.Name);
                    var newStatus = new PlayerStatusEntity(statusFromApi)
                    {
                        DbId = status.DbId
                    };

                    /* When user is offline, api returns 0 in playerId */
                    if (newStatus.playerId == 0) newStatus.playerId = newplayer.Id;

                    Mapper.Map(newStatus, status);
                    _statusController.PutPlayerStatusEntity(status.DbId, status);
                }
                else
                {
                    var statusFromApi = await _paladinsApi.GetPlayerStatus(newplayer.Name);
                    _statusController.PostPlayerStatusEntity(new PlayerStatusEntity(statusFromApi));
                }

                #endregion

                #region Update PlayerLoadouts

                var loadouts = _dbContext.PlayerLoadoutsEntities
                    .Where(l => l.PlayerId == newplayer.Id)
                    .ToList();

                var loadoutsFromApi = await _paladinsApi.GetPlayerLoadouts(newplayer.Id);
                if (loadoutsFromApi.Any())
                {
                    foreach (var loadout in loadouts)
                    {
                        var foundLoadout = loadoutsFromApi
                            .Find(l => l.DeckId == loadout.DeckId);
                        var selectedLoadout = new PlayerLoadoutsEntity(foundLoadout)
                        {
                            DbId = loadout.DbId
                        };
                        Mapper.Map(selectedLoadout, loadout);
                        _playerLoadoutsController.PutPlayerLoadoutsEntity(loadout.DbId, loadout);
                        loadoutsFromApi.Remove(foundLoadout);
                    }
                }

                foreach (var loadout in loadoutsFromApi)
                {
                    var selectedLoadout = new PlayerLoadoutsEntity(loadout);
                    _playerLoadoutsController.PostPlayerLoadoutsEntity(selectedLoadout);
                }

                #endregion

                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (NotFoundException)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        [Route("api/History/{id}")]
        [ResponseType(typeof(IQueryable<MatchHistory>))]
        public async Task<IHttpActionResult> RetrievePlayerMatchHistoryAsync(int id)
        {
            var player = _dbContext.PlayerEntities
                .FirstOrDefault(p => p.Id == id);

            if (player == null) return NotFound();

            var matches = await _paladinsApi.GetMatchHistory(id);

            if (matches == null) return NotFound();

            return Ok(matches);
        }

        // PUT: api/playerentities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayerEntity(int id, PlayerEntity playerEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playerEntity.DbId)
            {
                return BadRequest();
            }
            
            _dbContext.Entry(playerEntity).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                {
                    PostPlayerEntity(playerEntity);
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/playerentities
        [ResponseType(typeof(PlayerEntity))]
        public IHttpActionResult PostPlayerEntity(PlayerEntity playerEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.PlayerEntities.Add(playerEntity);
            _dbContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = playerEntity.DbId }, playerEntity);
        }

        // DELETE: api/tests/5
        [ResponseType(typeof(PlayerEntity))]
        public IHttpActionResult DeletePlayerEntity(int id)
        {
            var playerEntity = _dbContext.PlayerEntities.Find(id);
            if (playerEntity == null)
            {
                return NotFound();
            }

            _dbContext.PlayerEntities.Remove(playerEntity);
            _dbContext.SaveChanges();

            return Ok(playerEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntityExists(int id)
        {
            return _dbContext.PlayerEntities.Count(e => e.DbId == id) > 0;
        }
    }
}
