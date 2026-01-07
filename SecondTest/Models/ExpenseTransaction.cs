using System;

namespace DigitalPettyCashLedger.Models
{
    /// <summary>
    /// Represents an expense transaction.
    /// Inherits from Transaction.
    /// </summary>
    public class ExpenseTransaction : Transaction
    {
        // Expense category (Office, Food, Travel)
        public string Category { get; }

        public ExpenseTransaction(
            int id,
            DateTime date,
            decimal amount,
            string description,
            string category)
            : base(id, date, amount, description)
        {
            Category = category;
        }

        /// <summary>
        /// Returns expense-specific summary.
        /// </summary>
        public override string GetSummary()
        {
            return $"[EXPENSE] {Date:d} | Amount: {Amount} | Category: {Category}";
        }
    }
}
