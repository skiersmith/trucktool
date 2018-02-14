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
    public class RecordsController : Controller
    {
        private readonly UserRepository users;
        private readonly RecordRepository db;
        public RecordsController(RecordRepository recordRepo, UserRepository userRepo)
        {
            db = recordRepo;
            users = userRepo;
        }
        // GET RECORDS BY RECORD ID
        [Authorize]
        [HttpGet("{id}")]
        public Record Get(int id)
        {
            Console.WriteLine(id);
            return db.GetById(id);
        }
        // POST NEW RECORD
        // [Authorize]
        // [HttpPost]
        // public Vault Post([FromBody]Vault vault)
        // {
        //     var user= HttpContext.User;
        //     var id = user.Identity.Name;
        //     UserReturnModel activeUser = null;
        //     if(id != null)
        //     {
        //         activeUser = users.GetUserById(id);
        //     }
        //     var uid = activeUser.Id;
        //     vault.UserId = uid;
        //     return db.Add(vault);
        // }
        // PUT EDIT RECORD
        // [Authorize]
        // [HttpPut("{id}")]
        // public Record Put(int id, [FromBody]Record record)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         return db.GetOneByIdAndUpdate(id, record);
        //     }
        //     return null;
        // }
        // DELETE VAULT
        [Authorize]
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return db.FindByIdAndRemove(id);
        }
    }
}