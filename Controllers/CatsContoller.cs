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

          public StatesController(AnimalShelterAPIContext db)
          {
              _db = db;
          }

          [HttpGet("dogs")]
          public ActionResult<IEnumerable<Cat>> Get(string name)
          {
              var query = _db.Cats.AsQueryable();
              if (name != null)
              {
                  query = query.Where(entry => entry.Name == name);
              }
              return query.ToList();
          }
      }
}