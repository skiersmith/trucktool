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
    public class RecordRepository
    {
        private readonly IDbConnection _db;

        public RecordRepository(IDbConnection db)
        {
            _db = db;
        }
        
       
        // GET RECORD BY RECORD ID
        public Record GetById(int id)
        {
            Console.WriteLine("THIS IS THE GET REQUEST ID: ", id);
            return _db.QueryFirstOrDefault<Record>($"SELECT * FROM vaults WHERE id = {id}", id);
        }
        //CREATE NEW RECORD  TO BE CONTINUED
        // public Record Add(Record vault)
        // {
        //     // int id = _db.ExecuteScalar<int>("INSERT INTO records (Name, Description, UserId)"
        //     //             + " VALUES(@Name, @Description, @UserId); SELECT LAST_INSERT_ID()", new
        //     //             {
        //     //                 vault.Name, 
        //     //                 vault.Description,
        //     //                 vault.UserId,
        //     //             });
        //     // vault.Id = id;
        //     // return vault;
        // }
        //EDIT RECORD
        public Record GetOneByIdAndUpdate(int id, Record record)
        {
            return _db.QueryFirstOrDefault<Record>($@"
                UPDATE records SET  
                    Name = @Name, 
                    Description = @Description, 
                    UserId = @UserId
                WHERE id = {id};
                SELECT * FROM records WHERE id = {id};", record);
        }
        //DELETE VAULT
        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute($@"
                DELETE FROM records WHERE Id = {id}
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}