using PayrollSystem.Models;

namespace PayrollSystem.Models
{
    /// <summary>
    /// Represents a Contract employee.
    /// Has lower deductions compared to full-time employees.
    /// </summary>
    public class ContractEmployee : Employee
    {
        public ContractEmployee(int id, string name, decimal salary) : base(id, name, salary)
        {
            EmployeeType = "Contract";
        }

        /// <summary>
        /// Overrides base method to calculate salary for contract employees.
        /// </summary>
        public override PaySlip CalculatePay()
        {
            decimal deduction = BaseSalary * 0.05m;
            decimal net = BaseSalary - deduction;

            return new PaySlip(
                Id,
                Name,
                EmployeeType,
                BaseSalary,
                deduction,
                net
            );
        }
    }
}
