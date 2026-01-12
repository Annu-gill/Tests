namespace PayrollSystem.Models
{
    /// <summary>
    /// PaySlip is a data transfer object.
    /// Stores the final payroll result for an employee.
    /// </summary>
    public class PaySlip
    {
        public int EmployeeId { get; }
        public string Name { get; }
        public string Type { get; }
        public decimal Gross { get; }
        public decimal Deductions { get; }
        public decimal Net { get; }

        public PaySlip(int id, string name, string type, decimal gross, decimal deductions, decimal net)
        {
            EmployeeId = id;
            Name = name;
            Type = type;
            Gross = gross;
            Deductions = deductions;
            Net = net;
        }
    }
}
