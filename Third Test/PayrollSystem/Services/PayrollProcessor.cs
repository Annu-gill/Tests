using System.Collections.Generic;
using PayrollSystem.Models;

namespace PayrollSystem.Services
{
    /// <summary>
    /// Delegate definition for salary processed notification.
    /// </summary>
    /// <param name="emp"></param>
    /// <param name="slip"></param>
    public delegate void SalaryProcessedHandler(Employee emp, PaySlip slip);

    /// <summary>
    /// PayrollProcessor handles payroll execution.
    /// Keeps business logic separate from Employee classes (SRP).
    /// </summary>
    public class PayrollProcessor
    {
        // Multicast delegate reference
        public SalaryProcessedHandler SalaryProcessed;
        /// <summary>
        /// Processes payroll using foreach loop.
        /// Uses polymorphism to calculate salary.
        /// </summary>
        /// <param name="employees"></param>
        public List<PaySlip> ProcessPayroll(List<Employee> employees)
        {
            List<PaySlip> payslips = new List<PaySlip>();

            foreach (Employee emp in employees)
            {
                // Polymorphic call
                PaySlip slip = emp.CalculatePay();
                payslips.Add(slip);

                // Notify HR & Finance
                SalaryProcessed?.Invoke(emp, slip);
            }

            return payslips;
        }
    }
}
