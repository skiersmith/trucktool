using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class KeepsController : Controller
    {
        private readonly KeepRepository db;
        public KeepsController(KeepRepository keepRepo)
        {
            db = keepRepo;
        }
        [HttpGet]
        public IEnumerable<Keep> GetAll()
        {
            return db.GetAll();
        }
        // GET api/values
        [HttpGet("users/{id}")]
        public IEnumerable<Keep> GetByUserId(int id)
        {
            Console.WriteLine("yo" + id);
            return db.GetAllByUserId(id);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Keep Get(int id)
        {
            return db.GetById(id);
        }

        // POST api/values
        [HttpPost]
        public Keep Post([FromBody]Keep keep)
        {
            var user = HttpContext.User;
            var id = Int32.Parse(user.Identity.Name);
            keep.UserId = id;
            return db.Add(keep);
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public Keep Put(int id, [FromBody]Keep keep)
        {
            if (ModelState.IsValid)
            {
                return db.GetOneByIdAndUpdate(id, keep);
            }
            return null;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return db.FindByIdAndRemove(id);
        }
    }
}