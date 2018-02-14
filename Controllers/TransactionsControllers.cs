using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        private readonly TransactionRepository db;
         private readonly UserRepository users;
        public TransactionsController(TransactionRepository transactionRepo, UserRepository userRepo)
        {
            db = transactionRepo;
            users = userRepo;
        }
        [HttpGet]
        public IEnumerable<Transaction> GetAll()
        {
            return db.GetAll();
        }
        // GET api/values
        [Authorize]
        [HttpGet("users/{id}")]
        public IEnumerable<Transaction> GetAllByUserId()
        {
            var user= HttpContext.User;
            var id = user.Identity.Name;
            UserReturnModel activeUser = null;
            if(id != null)
            {
                activeUser = users.GetUserById(id);
            }
            var uid = activeUser.Id;
            return db.GetAllByUserId(uid);
        }

        // GET api/values/5
        [HttpGet("{dot}")]
        public Transaction Get(int dot)
        {
            return db.GetByDot(dot);
        }

        // POST api/values
        [HttpPost]
        public Transaction Post([FromBody]Transaction transaction)
        {
            var user = HttpContext.User;
            var id = Int32.Parse(user.Identity.Name);
            transaction.UserId = id;
            return db.Add(transaction);
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public Transaction Put(int id, [FromBody]Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                return db.GetOneByDotAndUpdate(id, transaction);
            }
            return null;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return db.FindByDotAndRemove(id);
        }
    }
}