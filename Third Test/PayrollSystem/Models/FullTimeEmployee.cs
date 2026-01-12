using PayrollSystem.Models;

namespace PayrollSystem.Models
{
    /// <summary>
    /// Represents a Full-Time employee.
    /// Applies tax and insurance deductions.
    /// </summary>
    public class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(int id, string name, decimal salary) : base(id, name, salary)
        {
            EmployeeType = "Full-Time";
        }

        /// <summary>
        /// Overrides base method to calculate salary for full-time employees.
        /// </summary>
        public override PaySlip CalculatePay()
        {
            decimal tax = BaseSalary * 0.10m;
            decimal insurance = BaseSalary * 0.05m;
            decimal net = BaseSalary - (tax + insurance);

            return new PaySlip(
                Id,
                Name,
                EmployeeType,
                BaseSalary,
                tax + insurance,
                net
            );
        }
    }
}
