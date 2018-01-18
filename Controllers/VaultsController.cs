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
    public class VaultsController : Controller
    {
        private readonly UserRepository users;
        private readonly VaultRepository db;
        public VaultsController(VaultRepository vaultRepo, UserRepository userRepo)
        {
            db = vaultRepo;
            users = userRepo;
        }
        // GET VAULTS BY USER ID
        [Authorize]
        [HttpGet("users/{id}")]
        public IEnumerable<Vault> GetbyUserID()
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
        // GET VAULT BY VAULT ID
        [Authorize]
        [HttpGet("{id}")]
        public Vault Get(int id)
        {
            Console.WriteLine(id);
            return db.GetById(id);
        }
        // POST NEW VAULT
        [Authorize]
        [HttpPost]
        public Vault Post([FromBody]Vault vault)
        {
            var user= HttpContext.User;
            var id = user.Identity.Name;
            UserReturnModel activeUser = null;
            if(id != null)
            {
                activeUser = users.GetUserById(id);
            }
            var uid = activeUser.Id;
            vault.UserId = uid;
            return db.Add(vault);
        }
        // PUT EDIT VAULT
        [Authorize]
        [HttpPut("{id}")]
        public Vault Put(int id, [FromBody]Vault vault)
        {
            if (ModelState.IsValid)
            {
                return db.GetOneByIdAndUpdate(id, vault);
            }
            return null;
        }
        // DELETE VAULT
        [Authorize]
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return db.FindByIdAndRemove(id);
        }
    }
}