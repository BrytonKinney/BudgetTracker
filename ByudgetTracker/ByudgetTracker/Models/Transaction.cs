using System;

namespace ByudgetTracker.Models
{
    public class TransactionModel
    {
        /// <summary>
        /// The transaction id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The transaction description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The transaction amount
        /// </summary>
        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}