using System;
using System.Collections.Generic;
using System.Linq;
using DigitalPettyCashLedger.Models;
using DigitalPettyCashLedger.Utilities;

namespace DigitalPettyCashLedger.Ledger
{
    /// <summary>
    /// Generic ledger class to store transactions.
    /// Enforces compile-time type safety.
    /// </summary>
    public class Ledger<T> where T : Transaction
    {
        // Internal collection to store transactions
        private readonly List<T> transactions = new List<T>();

        /// <summary>
        /// Adds a transaction to the ledger.
        /// </summary>
        public void AddEntry(T entry)
        {
            transactions.Add(entry);
        }

        /// <summary>
        /// Returns transactions for a specific date.
        /// </summary>
        public List<T> GetTransactionsByDate(DateTime date)
        {
            return transactions
                .Where(t => t.Date.Date == date.Date)
                .ToList();
        }

        /// <summary>
        /// Calculates total using utility class.
        /// </summary>
        public decimal CalculateTotal()
        {
            return CalculationUtility.CalculateTotal(transactions);
        }

        /// <summary>
        /// Returns all stored transactions.
        /// </summary>
        public List<T> GetAllTransactions()
        {
            return transactions;
        }
    }
}
