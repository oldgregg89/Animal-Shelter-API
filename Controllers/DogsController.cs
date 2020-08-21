﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelterAPI.solution.Controllers
{
    public class DogsController : ControllerBase
    {
        
        private AnimalShelterContext _db;

        public DogsController(AnimalShelterAPIContext db)
        {
            _db = db;
        }

        // GET api/values
        [HttpGet("dogs")]
        public ActionResult<IEnumerable<Dog>> Get(string name)
        {
            var query = _db.Dogs.AsQueryable();
            if (name != null)
            {
                query = query.Where(entry => entry.Name == name);
            }
            return query.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll([FromQuery] UrlQuery urlQuery)
        {
            var validUrlQuery = new UrlQuery(urlQuery.PageNumber, urlQuery.PageSize);
            var pagedData = _db.Dogs
                .OrderBy(thing => thing.DogId)
                .Skip((validUrlQuery.PageNumber - 1) * validUrlQuery.PageSize)
                .Take(validUrlQuery.PageSize);
            return Ok(pagedData);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Dog> GetDetails(int id)
        {
            _db.Dog.Add(value);
            _db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Dog value)
        {
            value.DogId = id;
            _db.Entry(value).Dog = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var dogToDelete = _db.Dogs.FirstOrDefault(entry => entry.DogId == id);
            _db.Dog.Remove(dogToDelete);
            _db.SaveChanges();
        }
    }
}
