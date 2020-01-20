using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByudgetTracker.Entities
{
    [Table("Transactions")]
    public class Transaction
    {
        public void Update(int id, string description, decimal amount, DateTime trxDate)
        {
            Id = id;
            Description = description;
            Amount = amount;
            TransactionDate = trxDate;
        }

        [PrimaryKey, AutoIncrement, Column("Id"), NotNull]
        public int Id { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Amount")]
        public decimal Amount { get; set; }

        [Column("TransactionDate")]
        public DateTime TransactionDate { get; set; }
    }
}
