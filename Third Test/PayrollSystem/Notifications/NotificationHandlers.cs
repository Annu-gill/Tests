using System;
using PayrollSystem.Models;

namespace PayrollSystem.Notifications
{
    /// <summary>
    /// Contains notification logic.
    /// Demonstrates DELEGATES and MULTICAST DELEGATES.
    /// </summary>
    public static class NotificationHandlers
    {
        // HR notification
        public static void NotifyHR(Employee emp, PaySlip slip)
        {
            Console.WriteLine($"[HR] Salary processed for {emp.Name}");
        }

        // Finance notification
        public static void NotifyFinance(Employee emp, PaySlip slip)
        {
            Console.WriteLine($"[Finance] Net Salary {slip.Net} credited to {emp.Name}");
        }
    }
}
