using System;
using DigitalPettyCashLedger.Interfaces;

namespace DigitalPettyCashLedger.Models
{
    /// <summary>
    /// Abstract base class representing a financial transaction.
    /// Provides common properties for Income and Expense.
    /// </summary>
    public abstract class Transaction : IReportable
    {
        // Unique transaction identifier
        public int Id { get; }

        // Date of transaction
        public DateTime Date { get; }

        // Transaction amount (must be > 0)
        public decimal Amount { get; }

        // Description of transaction
        public string Description { get; }

        /// <summary>
        /// Protected constructor to prevent direct instantiation.
        /// Validates transaction amount.
        /// </summary>
        protected Transaction(int id, DateTime date, decimal amount, string description)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            Id = id;
            Date = date;
            Amount = amount;
            Description = description;
        }

        /// <summary>
        /// Abstract method implemented by child classes
        /// to provide transaction-specific summaries.
        /// </summary>
        public abstract string GetSummary();
    }
}
