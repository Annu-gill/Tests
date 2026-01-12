using System.Collections.Generic;
using PayrollSystem.Models;

namespace PayrollSystem.Data
{
    /// <summary>
    /// EmployeeData acts as an in-memory data store.
    /// Uses a static generic collection to store employees.
    /// </summary>

    public static class EmployeeData
    {
        // Static collection (shared across application)
        private static Dictionary<int, Employee> employeeList = new Dictionary<int, Employee>();

        // Adds employee to static collection
        public static void AddEmployee(Employee emp)
        {
            employeeList.Add(emp.Id, emp);
        }

        /// <summary>
        /// Returns all employees
        /// </summary>
        public static List<Employee> GetEmployees()
        {
            // Convert dictionary values to list
            return new List<Employee>(employeeList.Values);
        }

        /// <summary>
        /// Returns count
        /// </summary>
        public static int Count()
        {
            return employeeList.Count;
        }
    }
}
