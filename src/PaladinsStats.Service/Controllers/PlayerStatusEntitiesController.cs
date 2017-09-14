using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using PaladinsStats.Service.Models;

namespace PaladinsStats.Service.Controllers
{
    public class PlayerStatusEntitiesController : ApiController
    {
        private readonly PaladinsStatsServiceContext _dbContext = new PaladinsStatsServiceContext();

        // GET: api/playerstatusentities
        public IQueryable<PlayerStatusEntity> GetPlayerStatusEntities()
        {
            return _dbContext.PlayerStatusEntities;
        }

        [Route("api/Status/{id}")]
        // GET: api/playerstatusentities/5
        [ResponseType(typeof(PlayerStatusEntity))]
        public IHttpActionResult GetPlayerStatusEntity(int id)
        {
            var playerStatusEntity = _dbContext.PlayerStatusEntities.FirstOrDefault(a => a.playerId == id);
            if (playerStatusEntity == null)
            {
                return NotFound();
            }

            return Ok(playerStatusEntity);
        }

        // PUT: api/playerstatusentities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlayerStatusEntity(int id, PlayerStatusEntity playerStatusEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != playerStatusEntity.DbId)
            {
                return BadRequest();
            }

            _dbContext.Entry(playerStatusEntity).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                {
                    PostPlayerStatusEntity(playerStatusEntity);
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/playerstatusentities
        [ResponseType(typeof(PlayerStatusEntity))]
        public IHttpActionResult PostPlayerStatusEntity(PlayerStatusEntity playerStatusEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.PlayerStatusEntities.Add(playerStatusEntity);
            _dbContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = playerStatusEntity.DbId }, playerStatusEntity);
        }

        // DELETE: api/tests/5
        [ResponseType(typeof(PlayerStatusEntity))]
        public IHttpActionResult DeletePlayerStatusEntity(int id)
        {
            var playerStatusEntity = _dbContext.PlayerStatusEntities.Find(id);
            if (playerStatusEntity == null)
            {
                return NotFound();
            }

            _dbContext.PlayerStatusEntities.Remove(playerStatusEntity);
            _dbContext.SaveChanges();

            return Ok(playerStatusEntity);
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
            return _dbContext.PlayerStatusEntities.Count(e => e.DbId == id) > 0;
        }
    }
}
