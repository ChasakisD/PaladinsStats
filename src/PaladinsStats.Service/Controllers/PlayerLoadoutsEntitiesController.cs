using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PaladinsStats.Service.Models;

namespace PaladinsStats.Service.Controllers
{
    public class PlayerLoadoutsEntitiesController : ApiController
    {
        private readonly PaladinsStatsServiceContext _dbContext = new PaladinsStatsServiceContext();

        // GET: api/PlayerLoadoutsEntities
        public IQueryable<PlayerLoadoutsEntity> GetPlayerLoadoutsEntities()
        {
            return _dbContext.PlayerLoadoutsEntities;
        }
        
        [Route("api/Loadouts/{id}")]
        [ResponseType(typeof(IEnumerable<PlayerLoadoutsEntity>))]
        public IHttpActionResult GetPlayerLoadoutsEntity(int id)
        {
            var playerLoadoutsEntity = _dbContext.PlayerLoadoutsEntities.Where(l => l.PlayerId == id).ToList();
            if (!playerLoadoutsEntity.Any())
            {
                return NotFound();
            }

            foreach (var loadout in playerLoadoutsEntity)
            {
                var items = _dbContext.LoadoutItemEntities
                    .Where(i => i.DeckId == loadout.DeckId)
                    .ToList();
                loadout.LoadoutItems = new List<LoadoutItemEntity>(items);
            }

            return Ok(playerLoadoutsEntity);
        }

        // PUT: api/PlayerLoadoutsEntities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayerLoadoutsEntity(int id, PlayerLoadoutsEntity playerLoadoutsEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playerLoadoutsEntity.DbId)
            {
                return BadRequest();
            }

            _dbContext.Entry(playerLoadoutsEntity).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerLoadoutsEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PlayerLoadoutsEntities
        [ResponseType(typeof(PlayerLoadoutsEntity))]
        public IHttpActionResult PostPlayerLoadoutsEntity(PlayerLoadoutsEntity playerLoadoutsEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.PlayerLoadoutsEntities.Add(playerLoadoutsEntity);
            _dbContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = playerLoadoutsEntity.DbId }, playerLoadoutsEntity);
        }

        // DELETE: api/PlayerLoadoutsEntities/5
        [ResponseType(typeof(PlayerLoadoutsEntity))]
        public IHttpActionResult DeletePlayerLoadoutsEntity(int id)
        {
            var playerLoadoutsEntity = _dbContext.PlayerLoadoutsEntities.Find(id);
            if (playerLoadoutsEntity == null)
            {
                return NotFound();
            }

            _dbContext.PlayerLoadoutsEntities.Remove(playerLoadoutsEntity);
            _dbContext.SaveChanges();

            return Ok(playerLoadoutsEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerLoadoutsEntityExists(int id)
        {
            return _dbContext.PlayerLoadoutsEntities.Count(e => e.DbId == id) > 0;
        }
    }
}