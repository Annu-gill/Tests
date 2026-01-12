using System;
using OnlineOrderProcessing.Models;

namespace OnlineOrderProcessing.Services
{
    /// <summary>
    /// Responsible only for reporting.
    /// Keeps reporting separate from business logic.
    /// </summary>
    public class ReportService
    {
        public void PrintOrderReport(Order order)
        {
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine($"Order ID: {order.Id}");
            Console.WriteLine($"Customer: {order.Customer.Name}");
            Console.WriteLine($"Current Status: {order.Status}");

            Console.WriteLine("Items:");
            foreach (var item in order.Items)
            {
                Console.WriteLine($"- {item.Product.Name} x {item.Quantity}");
            }

            Console.WriteLine($"Total Amount: {order.CalculateTotal()}");

            Console.WriteLine("Status Timeline:");
            foreach (var log in order.StatusHistory)
            {
                Console.WriteLine($"{log.ChangedOn}: {log.OldStatus} → {log.NewStatus}");
            }
        }
    }
}
