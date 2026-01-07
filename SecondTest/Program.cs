using System;
using System.Collections.Generic;
using DigitalPettyCashLedger.Models;
using DigitalPettyCashLedger.Ledger;

namespace DigitalPettyCashLedger
{
    /// <summary>
    /// Entry point of Digital Petty Cash Ledger System.
    /// Handles user interaction and workflow.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing ledgers
            Ledger<IncomeTransaction> incomeLedger = new Ledger<IncomeTransaction>();
            Ledger<ExpenseTransaction> expenseLedger = new Ledger<ExpenseTransaction>();

            Console.WriteLine("=== DIGITAL PETTY CASH LEDGER SYSTEM ===");

            bool continueEntry = true;
            int idCounter = 1;

            // Input Loop(for each transaction as mentioned in DFD)
            while (continueEntry)
            {
                Console.WriteLine("\nSelect Transaction Type:");
                Console.WriteLine("1. Income");
                Console.WriteLine("2. Expense");
                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                Console.Write("Enter amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());

                Console.Write("Enter description: ");
                string description = Console.ReadLine();

                Console.Write("Enter date (yyyy-mm-dd): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Enter income source (Main Cash / Bank): ");
                    string source = Console.ReadLine();

                    IncomeTransaction income = new IncomeTransaction(
                        idCounter++, date, amount, description, source);

                    incomeLedger.AddEntry(income);
                    Console.WriteLine("Income recorded successfully.");
                }
                else if (choice == 2)
                {
                    Console.Write("Enter expense category (Office / Food / Travel): ");
                    string category = Console.ReadLine();

                    ExpenseTransaction expense = new ExpenseTransaction(
                        idCounter++, date, amount, description, category);

                    expenseLedger.AddEntry(expense);
                    Console.WriteLine("Expense recorded successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }

                Console.Write("\nDo you want to add another transaction? (y/n): ");
                continueEntry = Console.ReadLine().ToLower() == "y";
            }

            // Summary Output
            Console.WriteLine("\n---- TRANSACTION SUMMARY ----");

            List<Transaction> allTransactions = new List<Transaction>();
            allTransactions.AddRange(incomeLedger.GetAllTransactions());
            allTransactions.AddRange(expenseLedger.GetAllTransactions());

            foreach (Transaction transaction in allTransactions)
            {
                Console.WriteLine(transaction.GetSummary());
            }

            // Calculations
            decimal totalIncome = incomeLedger.CalculateTotal();
            decimal totalExpense = expenseLedger.CalculateTotal();
            decimal netBalance = totalIncome - totalExpense;

            Console.WriteLine("\n---- FINAL TOTALS ----");
            Console.WriteLine($"Total Income  : {totalIncome}");
            Console.WriteLine($"Total Expense : {totalExpense}");
            Console.WriteLine($"Net Balance  : {netBalance}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}



