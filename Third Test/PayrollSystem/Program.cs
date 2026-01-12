using System;
using System.Collections.Generic;
using PayrollSystem.Models;
using PayrollSystem.Services;
using PayrollSystem.Notifications;

namespace PayrollSystem
{
    /// <summary>
    /// Program class is the ENTRY POINT.
    /// Handles user input and coordinates services.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Dictionary used for fast lookup by Employee ID
            Dictionary<int, Employee> employeeMap = new Dictionary<int, Employee>();

            Console.WriteLine("===== PAYROLL SYSTEM =====");
            Console.WriteLine("Enter details for 6 employees\n");

            // User input loop
            while (employeeMap.Count < 6)
            {
                try
                {
                    Console.Write("Employee ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Type (1 = Full-Time, 2 = Contract): ");
                    int type = int.Parse(Console.ReadLine());

                    Console.Write("Salary: ");
                    decimal salary = decimal.Parse(Console.ReadLine());

                    // Polymorphic object creation
                    Employee emp = type == 1
                        ? new FullTimeEmployee(id, name, salary)
                        : new ContractEmployee(id, name, salary);

                    employeeMap.Add(id, emp);
                    Console.WriteLine("Employee added successfully ✔\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Re-enter details.\n");
                }
            }

            // Convert Dictionary to List
            List<Employee> employees = new List<Employee>(employeeMap.Values);

            PayrollProcessor processor = new PayrollProcessor();

            // Multicast delegate subscriptions
            processor.SalaryProcessed += NotificationHandlers.NotifyHR;
            processor.SalaryProcessed += NotificationHandlers.NotifyFinance;

            // Process payroll
            List<PaySlip> slips = processor.ProcessPayroll(employees);

            Console.WriteLine("\n===== PAYSLIP DETAILS =====");
            foreach (PaySlip slip in slips)
            {
                Console.WriteLine(
                    $"ID:{slip.EmployeeId}, Name:{slip.Name}, Type:{slip.Type}, " +
                    $"Gross:{slip.Gross}, Deduction:{slip.Deductions}, Net:{slip.Net}"
                );
            }

            // Print summary
            ReportService report = new ReportService();
            report.PrintSummary(slips);

            Console.WriteLine("\nPayroll completed successfully.");
            Console.ReadKey();
        }
    }
}
