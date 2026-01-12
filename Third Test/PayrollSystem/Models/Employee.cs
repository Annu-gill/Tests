using System;

namespace PayrollSystem.Models
{
    /// <summary>
    /// Employee is an ABSTRACT base class.
    /// It represents common data and behavior for all employee types.
    /// Demonstrates Encapsulation, Inheritance, Runtime Polymorphism
    /// </summary>
    public abstract class Employee
    {
        // Unique employee identifier
        public int Id { get; }

        // Employee name
        public string Name { get; }

        // Type of employee (Full-Time / Contract)
        public string EmployeeType { get; protected set; }

        // Base salary is protected so derived classes can access it
        protected decimal BaseSalary;

        // Base constructor with validation
        protected Employee(int id, string name, decimal salary)
        {
            if (salary < 0)
                throw new ArgumentException("Salary cannot be negative");

            Id = id;
            Name = name;
            BaseSalary = salary;
        }
        /// <summary>
        /// Polymorphic method:
        /// Each derived class MUST implement its own salary calculation.
        /// </summary>
        public abstract PaySlip CalculatePay();
    }
}
