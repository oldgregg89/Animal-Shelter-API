using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnimalShelterAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace AnimalShelterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private AnimalShelterContext _db;

        public AnimalsController(AnimalShelterContext db)
        {
            _db = db;
        }
        [HttpGet("animals")]
        public ActionResult<IEnumerable<Animal>> Get(string name)
        {
            var query = _db.Animals.AsQueryable();
            if (name != null)
            {
                query = query.Where(entry => entry.Name == name);
            }
            return query.ToList();
        }

        // GET api/values/5
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] UrlQuery urlQuery)
        {
            var validUrlQuery = new UrlQuery(urlQuery.PageNumber, urlQuery.PageSize);
            var pagedData = _db.Animals
                .OrderBy(thing => thing.AnimalId)
                .Skip((validUrlQuery.PageNumber - 1) * validUrlQuery.PageSize)
                .Take(validUrlQuery.PageSize);
            return Ok(pagedData);
        }
        
        // GET 
        [HttpGet("{id}")]        
        public ActionResult<Animal> GetDetails(int id)
        {
            return _db.Animals.FirstOrDefault(c => c.AnimalId == id);
        }
        

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Animal value)
        {
            _db.Animals.Add(value);
            _db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Animal value)
        {
            value.AnimalId = id;
            _db.Entry(value).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var animalToDelete = _db.Animals.FirstOrDefault(entry => entry.AnimalId == id);
            _db.Animals.Remove(animalToDelete);
            _db.SaveChanges();
        }
    }
}