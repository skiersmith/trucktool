using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using keepr.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace keepr.Repositories
{
    public class VaultKeepRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepRepository(IDbConnection db)
        {
            _db = db;
        }
        // GET ALL KEEPS IN A VAULT
        public IEnumerable<Keep> GetAll(int id)
        {
            return _db.Query<Keep>($@"
            SELECT * FROM vaultkeeps vk
            INNER JOIN keeps k ON k.id = vk.keepId 
            WHERE (vaultId = {id})");
        }
        //ADD KEEP TO VAULT
        public VaultKeep Add(VaultKeep vaultkeep)
        {
            var id = _db.ExecuteScalar<int>("INSERT INTO vaultkeeps (UserId, VaultId, KeepID)"
                        + " VALUES(@UserId, @VaultId, @KeepID); SELECT LAST_INSERT_ID()", new
                        {
                            vaultkeep.UserId, 
                            vaultkeep.VaultId,
                            vaultkeep.KeepId,
                        });
          vaultkeep.Id = id;
          return vaultkeep;
        }
        //REMOVE KEEP FROM VAULT
        public string FindByIdAndRemove(int vaultId, int id)
        {
            var success = _db.Execute($@"
                DELETE FROM vaultkeeps WHERE vaultId = {vaultId} AND keepId = {id}
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}