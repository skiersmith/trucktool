using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class UserRecordsController : Controller
    {
        private readonly UserRecordRepository db;
        public UserRecordsController(UserRecordRepository userrecordRepo)
        {
            db = userrecordRepo;
        }

        // GET ALL records FOR A user
        [HttpGet("{id}")]
        public IEnumerable<Record> GetByUser(int id)
        {
            return db.GetAll(id);
        }
        // POST ADD RECORD TO USER
        [HttpPost]
        public UserRecord Post([FromBody]UserRecord ur)
        {
           
            var user = HttpContext.User;
            var id = Int32.Parse(user.Identity.Name);
            ur.UserId = id;
            

            return db.Add(ur);
        }

        // DELETE REMOVE KEEP FROM VAULT
        [Authorize]
        [HttpDelete("users/{userId}/records/{recordId}")]
        public String Delete(int userId, int id)
        {
            return db.FindByIdAndRemove(userId, id);
        }
    }
}