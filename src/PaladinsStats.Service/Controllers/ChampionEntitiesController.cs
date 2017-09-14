using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using PaladinsStats.Service.Models;

namespace PaladinsStats.Service.Controllers
{
    public class ChampionEntitiesController : ApiController
    {
        private readonly PaladinsStatsServiceContext _dbContext = new PaladinsStatsServiceContext();

        // GET: api/championentities
        public IQueryable<ChampionEntity> GetChampionEntities()
        {
            return _dbContext.ChampionEntities;
        }

        // GET: api/championentities/5
        [ResponseType(typeof(ChampionEntity))]
        public IHttpActionResult GetChampionEntity(int id)
        {
            var championEntity = _dbContext.ChampionEntities.Find(id);
            if (championEntity == null)
            {
                return NotFound();
            }

            return Ok(championEntity);
        }

        // PUT: api/championentities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChampionEntity(int id, ChampionEntity championEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != championEntity.DbId)
            {
                return BadRequest();
            }

            _dbContext.Entry(championEntity).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                {
                    PostChampionEntity(championEntity);
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/championentities
        [ResponseType(typeof(ChampionEntity))]
        public IHttpActionResult PostChampionEntity(ChampionEntity championEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.ChampionEntities.Add(championEntity);
            _dbContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = championEntity.DbId }, championEntity);
        }

        // DELETE: api/tests/5
        [ResponseType(typeof(ChampionEntity))]
        public IHttpActionResult DeleteChampionEntity(int id)
        {
            var championEntity = _dbContext.ChampionEntities.Find(id);
            if (championEntity == null)
            {
                return NotFound();
            }

            _dbContext.ChampionEntities.Remove(championEntity);
            _dbContext.SaveChanges();

            return Ok(championEntity);
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
            return _dbContext.ChampionEntities.Count(e => e.DbId == id) > 0;
        }
    }
}
