using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using PaladinsStats.Service.Models;

namespace PaladinsStats.Service.Controllers
{
    public class LoadoutItemEntitiesController : ApiController
    {
        private readonly PaladinsStatsServiceContext _dbContext = new PaladinsStatsServiceContext();

        // GET: api/LoadoutItemEntities
        public IQueryable<LoadoutItemEntity> GetLoadoutItemEntities()
        {
            return _dbContext.LoadoutItemEntities;
        }

        // GET: api/LoadoutItemEntities/5
        [ResponseType(typeof(LoadoutItemEntity))]
        public IHttpActionResult GetLoadoutItemEntity(int id)
        {
            var loadoutItemEntity = _dbContext.LoadoutItemEntities.Find(id);
            if (loadoutItemEntity == null)
            {
                return NotFound();
            }

            return Ok(loadoutItemEntity);
        }

        // PUT: api/LoadoutItemEntities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLoadoutItemEntity(int id, LoadoutItemEntity loadoutItemEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loadoutItemEntity.DbId)
            {
                return BadRequest();
            }

            _dbContext.Entry(loadoutItemEntity).State = EntityState.Modified;

            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoadoutItemEntityExists(id))
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

        // POST: api/LoadoutItemEntities
        [ResponseType(typeof(LoadoutItemEntity))]
        public IHttpActionResult PostLoadoutItemEntity(LoadoutItemEntity loadoutItemEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.LoadoutItemEntities.Add(loadoutItemEntity);
            _dbContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = loadoutItemEntity.DbId }, loadoutItemEntity);
        }

        // DELETE: api/LoadoutItemEntities/5
        [ResponseType(typeof(LoadoutItemEntity))]
        public IHttpActionResult DeleteLoadoutItemEntity(int id)
        {
            var loadoutItemEntity = _dbContext.LoadoutItemEntities.Find(id);
            if (loadoutItemEntity == null)
            {
                return NotFound();
            }

            _dbContext.LoadoutItemEntities.Remove(loadoutItemEntity);
            _dbContext.SaveChanges();

            return Ok(loadoutItemEntity);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LoadoutItemEntityExists(int id)
        {
            return _dbContext.LoadoutItemEntities.Count(e => e.DbId == id) > 0;
        }
    }
}