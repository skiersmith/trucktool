using System;

namespace keepr.Models
{

    public class RecordTransaction
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int RecordId { get; set; }
        
        public int TransactionId { get; set; }

    }
}