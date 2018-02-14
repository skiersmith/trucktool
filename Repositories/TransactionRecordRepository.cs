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
    public class RecordTransactionRepository
    {
        private readonly IDbConnection _db;

        public RecordTransactionRepository(IDbConnection db)
        {
            _db = db;
        }
        // GET ALL KEEPS IN A VAULT
        public IEnumerable<Transaction> GetAll(int id)
        {
            return _db.Query<Transaction>($@"
            SELECT * FROM recordtransaction rt
            INNER JOIN transactions t ON t.id = rt.transactionId 
            WHERE (recordId = {id})");
        }
        //ADD KEEP TO VAULT
        public RecordTransaction Add(RecordTransaction recordtransaction)
        {
            var id = _db.ExecuteScalar<int>("INSERT INTO recordtransactions (UserId, RecordId, TransactionId)"
                        + " VALUES(@UserId, @RecordId, @TransactionId); SELECT LAST_INSERT_ID()", new
                        {
                            recordtransaction.UserId, 
                            recordtransaction.RecordId,
                            recordtransaction.TransactionId,
                        });
          recordtransaction.Id = id;
          return recordtransaction;
        }
        //REMOVE KEEP FROM VAULT
        public string FindByIdAndRemove(int dot, int id)
        {
            var success = _db.Execute($@"
                DELETE FROM recordtransactions WHERE dot = {dot} AND transactionId = {id}
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}