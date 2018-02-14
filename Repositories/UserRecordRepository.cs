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
    public class UserRecordRepository
    {
        private readonly IDbConnection _db;

        public UserRecordRepository(IDbConnection db)
        {
            _db = db;
        }
        // GET ALL records FOR A user
        public IEnumerable<Record> GetAll(int id)
        {
            return _db.Query<Record>($@"
            SELECT * FROM userrecords ur
            INNER JOIN records r ON r.id = ur.recordid 
            WHERE (userid = {id})");
        }
        //ADD Records TO User
        public UserRecord Add(UserRecord userrecord)
        {
            var id = _db.ExecuteScalar<int>("INSERT INTO userrecords (UserId, RecordID)"
                        + " VALUES(@UserId, @RecordID); SELECT LAST_INSERT_ID()", new
                        {
                            userrecord.UserId, 
                            userrecord.RecordId,
                        });
          userrecord.Id = id;
          return userrecord;
        }
        //REMOVE Record FROM user
        public string FindByIdAndRemove(int userId, int id)
        {
            var success = _db.Execute($@"
                DELETE FROM userrecords WHERE userId = {userId} AND recordId = {id}
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}