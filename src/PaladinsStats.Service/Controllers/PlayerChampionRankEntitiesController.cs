using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PaladinsStats.Service.Models;

namespace PaladinsStats.Service.Controllers
{
    public class PlayerChampionRankEntitiesController : ApiController
    {
        private readonly PaladinsStatsServiceContext _dbContext = new PaladinsStatsServiceContext();

        // GET: api/playerchampionrankentities
        [Route("api/ChampionRanks")]
        public IQueryable<PlayerChampionRankEntity> GetPlayerChampionRankEntities()
        {
            return _dbContext.PlayerChampionRankEntities;
        }

        [Route("api/ChampionRanks/{id}")]
        // GET: api/playerchampionrankentities/5
        [ResponseType(typeof(PlayerChampionRankEntity))]
        public IHttpActionResult GetPlayerChampionRankEntity(int id)
        {
            var playerChampionRankEntity = _dbContext.PlayerChampionRankEntities.Find(id);
            if (playerChampionRankEntity == null)
            {
                return NotFound();
            }

            return Ok(playerChampionRankEntity);
        }

        // PUT: api/playerchampionrankentities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayerChampionRankEntity(int id, PlayerChampionRankEntity playerChampionRankEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playerChampionRankEntity.DbId)
            {
                return BadRequest();
            }

            _dbContext.Entry(playerChampionRankEntity).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                {
                    PostPlayerChampionRankEntity(playerChampionRankEntity);
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/playerchampionrankentities
        [ResponseType(typeof(PlayerChampionRankEntity))]
        public IHttpActionResult PostPlayerChampionRankEntity(PlayerChampionRankEntity playerChampionRankEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.PlayerChampionRankEntities.Add(playerChampionRankEntity);
            _dbContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = playerChampionRankEntity.DbId }, playerChampionRankEntity);
        }

        // DELETE: api/tests/5
        [ResponseType(typeof(PlayerChampionRankEntity))]
        public IHttpActionResult DeletePlayerChampionRankEntity(int id)
        {
            var playerChampionRankEntity = _dbContext.PlayerChampionRankEntities.Find(id);
            if (playerChampionRankEntity == null)
            {
                return NotFound();
            }

            _dbContext.PlayerChampionRankEntities.Remove(playerChampionRankEntity);
            _dbContext.SaveChanges();

            return Ok(playerChampionRankEntity);
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
            return _dbContext.PlayerChampionRankEntities.Count(e => e.DbId == id) > 0;
        }
    }
}
