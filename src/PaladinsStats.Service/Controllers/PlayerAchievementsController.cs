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
    public class PlayerAchievementsController : ApiController
    {
        private readonly PaladinsStatsServiceContext _dbContext = new PaladinsStatsServiceContext();

        // GET: api/playerachievementsentities
        [Route("api/Achievements")]
        public IQueryable<PlayerAchievementsEntity> GetPlayerAchievementsEntities()
        {
            return _dbContext.PlayerAchievementsEntities;
        }

        [Route("api/Achiements/{id}")]
        // GET: api/playerachievementsentities/5
        [ResponseType(typeof(PlayerAchievementsEntity))]
        public IHttpActionResult GetPlayerAchievementsEntity(int id)
        {
            var playerAchievementsEntity = _dbContext.PlayerAchievementsEntities.FirstOrDefault(a => a.Id == id);
            if (playerAchievementsEntity == null)
            {
                return NotFound();
            }

            return Ok(playerAchievementsEntity);
        }

        // PUT: api/playerachievementsentities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayerAchievementsEntity(int id, PlayerAchievementsEntity playerAchievementsEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playerAchievementsEntity.DbId)
            {
                return BadRequest();
            }

            _dbContext.Entry(playerAchievementsEntity).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                {
                    PostPlayerAchievementsEntity(playerAchievementsEntity);
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/playerachievementsentities
        [ResponseType(typeof(PlayerAchievementsEntity))]
        public IHttpActionResult PostPlayerAchievementsEntity(PlayerAchievementsEntity playerAchievementsEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.PlayerAchievementsEntities.Add(playerAchievementsEntity);
            _dbContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = playerAchievementsEntity.DbId }, playerAchievementsEntity);
        }

        // DELETE: api/tests/5
        [ResponseType(typeof(PlayerAchievementsEntity))]
        public IHttpActionResult DeletePlayerAchievementsEntity(int id)
        {
            var playerAchievementsEntity = _dbContext.PlayerAchievementsEntities.Find(id);
            if (playerAchievementsEntity == null)
            {
                return NotFound();
            }

            _dbContext.PlayerAchievementsEntities.Remove(playerAchievementsEntity);
            _dbContext.SaveChanges();

            return Ok(playerAchievementsEntity);
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
            return _dbContext.PlayerAchievementsEntities.Count(e => e.DbId == id) > 0;
        }
    }
}
