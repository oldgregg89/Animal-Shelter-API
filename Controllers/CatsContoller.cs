using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterAPI.solution.Controllers
{
    
    public class CatsController : ControllerBase
    {
      private AnimalShelterContext _db;

          public CatsController(AnimalShelterAPIContext db)
          {
              _db = db;
          }

          [HttpGet("cats")]
          public ActionResult<IEnumerable<Cat>> Get(string name)
          {
              var query = _db.Cat.AsQueryable();
              if (name != null)
              {
                  query = query.Where(entry => entry.Name == name);
              }
              return query.ToList();
          }

          [HttpGet("{id}")]
          public async Task<IActionResult> GetAll([FromQuery] UrlQuery urlQuery)
          {
              var validUrlQuery = new UrlQuery(urlQuery.PageNumber, urlQuery.PageSize);
              var pagedData = _db.Cats
                  .OrderBy(thing => thing.CatId)
                  .Skip((validUrlQuery.PageNumber - 1) * validUrlQuery.PageSize)
                  .Take(validUrlQuery.PageSize);
              return Ok(pagedData);
          }
          // POST api/values
        [HttpPost]
        public ActionResult<Cat> GetDetails(int id)
        {
            _db.Cat.Add(value);
            _db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cat value)
        {
            value.CatId = id;
            _db.Entry(value).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var catToDelete = _db.Cats.FirstOrDefault(entry => entry.CatId == id);
            _db.Cat.Remove(catToDelete);
            _db.SaveChanges();
        }
    }
  
}