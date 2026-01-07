using System;

namespace DigitalPettyCashLedger.Models
{
    /// <summary>
    /// Represents an income transaction (fund replenishment).
    /// Inherits from Transaction.
    /// </summary>
    public class IncomeTransaction : Transaction
    {
        // Source of income (Main Cash / Bank Transfer)
        public string Source { get; }

        public IncomeTransaction(
            int id,
            DateTime date,
            decimal amount,
            string description,
            string source)
            : base(id, date, amount, description)
        {
            Source = source;
        }

        /// <summary>
        /// Returns income-specific summary.
        /// Demonstrates method overriding.
        /// </summary>
        public override string GetSummary()
        {
            return $"[INCOME] {Date:d} | Amount: {Amount} | Source: {Source}";
        }
    }
}
