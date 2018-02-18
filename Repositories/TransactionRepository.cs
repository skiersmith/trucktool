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
    public class TransactionRepository
    {
        private readonly IDbConnection _db;

        public TransactionRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Transaction> GetAll()
        {
            return _db.Query<Transaction>("SELECT * FROM transactions");
        }
        
        public IEnumerable<Transaction> GetAllByUserId(int id)
        {
            return _db.Query<Transaction>($"SELECT * FROM transactions WHERE userid = {id}");
        }

        public IEnumerable<Transaction> GetByDot(int dot)
        {
            Console.WriteLine("THIS IS THE GET REQUEST #: ", dot);
            return _db.Query<Transaction>($"SELECT * FROM transactions WHERE Dot = {dot}", dot);
        }

        public Transaction Add(Transaction transaction)
        {
            int id = _db.ExecuteScalar<int>("INSERT INTO transactions (Dot, Notes, Status, UserId)"
                        + " VALUES(@Dot, @Notes, @Status, @UserId); SELECT LAST_INSERT_ID()", new
                        {
                            transaction.Dot, 
                            transaction.Notes,
                            transaction.Status,
                            transaction.UserId,
                        });
            // transaction.Id = id;
            return transaction;

        }

        public Transaction GetOneByDotAndUpdate(int dot, Transaction transaction)
        {
            return _db.QueryFirstOrDefault<Transaction>($@"
                UPDATE transactions 
                SET Dot = @Dot, 
                    Notes = @Notes, 
                    Status = @Status 
                WHERE Dot = {dot};
                SELECT * FROM transactions WHERE Dot = {dot};", transaction);
        }

        public string FindByDotAndRemove(int dot)
        {
            var success = _db.Execute($@"
                DELETE FROM transactions WHERE Dot = {dot}
            ", dot);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}