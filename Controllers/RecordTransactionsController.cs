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
    public class RecordTransactionsController : Controller
    {
        private readonly RecordTransactionRepository db;
        public RecordTransactionsController(RecordTransactionRepository recordtransactionRepo)
        {
            db = recordtransactionRepo;
        }

        // GET ALL KEEPS IN A VAULT
        [HttpGet("{id}")]
        public IEnumerable<Transaction> GetByVault(int id)
        {
            return db.GetAll(id);
        }
        // POST ADD KEEP TO VAULT
        [HttpPost]
        public RecordTransaction Post([FromBody]RecordTransaction rt)
        {
           
            var user = HttpContext.User;
            var id = Int32.Parse(user.Identity.Name);
            rt.UserId = id;
            

            return db.Add(rt);
        }

        // DELETE REMOVE KEEP FROM VAULT
        [Authorize]
        [HttpDelete("records/{recordId}/transactions/{id}")]
        public String Delete(int recordId, int id)
        {
            return db.FindByIdAndRemove(recordId, id);
        }
    }
}