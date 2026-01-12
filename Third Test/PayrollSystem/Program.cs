using System;
using System.Collections.Generic;
using PayrollSystem.Models;
using PayrollSystem.Services;
using PayrollSystem.Notifications;
using PayrollSystem.Data;

namespace PayrollSystem
{
    /// <summary>
    /// Entry point of the application.
    /// Takes user input and stores employees using EmployeeData class.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("===== PAYROLL SYSTEM =====");
            Console.WriteLine("Enter details for 6 employees\n");

            // USER INPUT
            while (EmployeeData.Count() < 6)
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

                    Employee emp = type == 1
                        ? new FullTimeEmployee(id, name, salary)
                        : new ContractEmployee(id, name, salary);

                    // Store in static collection
                    EmployeeData.AddEmployee(emp);

                    Console.WriteLine("Employee added successfully. \n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.WriteLine("Re-enter details.\n");
                }
            }

            // Fetch employees from EmployeeData
            List<Employee> employees = EmployeeData.GetEmployees();

            PayrollProcessor processor = new PayrollProcessor();

            // Delegate subscriptions (multicast)
            processor.SalaryProcessed += NotificationHandlers.NotifyHR;
            processor.SalaryProcessed += NotificationHandlers.NotifyFinance;

            // Payroll Processing
            List<PaySlip> slips = processor.ProcessPayroll(employees);

            Console.WriteLine("\n===== PAYSLIP DETAILS =====");
            foreach (PaySlip slip in slips)
            {
                Console.WriteLine(
                    $"ID:{slip.EmployeeId}, Name:{slip.Name}, Type:{slip.Type}, " +
                    $"Gross:{slip.Gross}, Deduction:{slip.Deductions}, Net:{slip.Net}"
                );
            }

            // Summary Report
            ReportService report = new ReportService();
            report.PrintSummary(slips);

            Console.WriteLine("\nPayroll completed successfully.");
            Console.ReadKey();
        }
    }
}
