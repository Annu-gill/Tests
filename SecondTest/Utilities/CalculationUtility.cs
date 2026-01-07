using System.Collections.Generic;
using DigitalPettyCashLedger.Models;

namespace DigitalPettyCashLedger.Utilities
{
    /// <summary>
    /// Static utility class responsible for calculations.
    /// Follows Single Responsibility Principle.
    /// </summary>
    public static class CalculationUtility
    {
        /// <summary>
        /// Calculates total amount of transactions.
        /// Uses generics to ensure type safety.
        /// </summary>
        public static decimal CalculateTotal<T>(List<T> transactions) where T : Transaction
        {
            decimal total = 0;

            foreach (var transaction in transactions)
            {
                total += transaction.Amount;
            }

            return total;
        }
    }
}
