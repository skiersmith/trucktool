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
    public class VaultKeepsController : Controller
    {
        private readonly VaultKeepRepository db;
        public VaultKeepsController(VaultKeepRepository vaultKeepRepo)
        {
            db = vaultKeepRepo;
        }

        // GET ALL KEEPS IN A VAULT
        [HttpGet("{id}")]
        public IEnumerable<Keep> GetByVault(int id)
        {
            return db.GetAll(id);
        }
        // POST ADD KEEP TO VAULT
        [HttpPost]
        public VaultKeep Post([FromBody]VaultKeep vk)
        {
           
            var user = HttpContext.User;
            var id = Int32.Parse(user.Identity.Name);
            vk.UserId = id;
            

            return db.Add(vk);
        }

        // DELETE REMOVE KEEP FROM VAULT
        [Authorize]
        [HttpDelete("vaults/{vaultId}/keeps/{id}")]
        public String Delete(int vaultId, int id)
        {
            return db.FindByIdAndRemove(vaultId, id);
        }
    }
}