using System;
using System.Collections.Generic;
using System.Linq;
using PayrollSystem.Models;

namespace PayrollSystem.Services
{
    /// <summary>
    /// Responsible ONLY for reporting.
    /// Follows Single Responsibility Principle.
    /// </summary>
    public class ReportService
    {
        public void PrintSummary(List<PaySlip> slips)
        {
            Console.WriteLine("\n===== PAYROLL SUMMARY =====");

            Console.WriteLine($"Total Employees: {slips.Count}");
            Console.WriteLine($"Total Payout: {slips.Sum(s => s.Net)}");

            PaySlip highest = slips.OrderByDescending(s => s.Net).First();
            Console.WriteLine($"Highest Net Salary: {highest.Name} ({highest.Net})");

            Console.WriteLine("\nEmployee Count by Type:");
            foreach (var group in slips.GroupBy(s => s.Type))
            {
                Console.WriteLine($"{group.Key}: {group.Count()}");
            }
        }
    }
}
