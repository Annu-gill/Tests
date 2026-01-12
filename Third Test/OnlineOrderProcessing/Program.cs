using System;
using System.Collections.Generic;
using OnlineOrderProcessing.Models;
using OnlineOrderProcessing.Services;
using OnlineOrderProcessing.Notifications;

namespace OnlineOrderProcessing
{
    /// <summary>
    /// Entry point of the application.
    /// Handles user input and coordinates all services.
    /// </summary>
    class Program
    {
        static void Main()
        {
            // Store products using Dictionary for fast lookup
            Dictionary<int, Product> products = new Dictionary<int, Product>();
            Console.WriteLine("Enter 5 Products");

            while (products.Count < 5)
            {
                Console.Write("Product ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                products.Add(id, new Product(id, name, price));
            }

            // Store customers
            List<Customer> customers = new List<Customer>();
            Console.WriteLine("\nEnter 3 Customers");

            while (customers.Count < 3)
            {
                Console.Write("Customer ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                customers.Add(new Customer(id, name));
            }

            // Store orders
            List<Order> orders = new List<Order>();
            Console.WriteLine("\nEnter 4 Orders");

            while (orders.Count < 4)
            {
                Console.Write("Order ID: ");
                int orderId = int.Parse(Console.ReadLine());

                Console.Write("Customer ID: ");
                int custId = int.Parse(Console.ReadLine());

                Customer customer = customers.Find(c => c.Id == custId);
                Order order = new Order(orderId, customer);

                Console.Write("Number of items: ");
                int itemCount = int.Parse(Console.ReadLine());

                int added = 0;
                while (added < itemCount)
                {
                    Console.Write("Product ID: ");
                    int pid = int.Parse(Console.ReadLine());

                    Console.Write("Quantity: ");
                    int qty = int.Parse(Console.ReadLine());

                    order.AddItem(new OrderItem(products[pid], qty));
                    added++;
                }

                orders.Add(order);
                Console.WriteLine("Order created successfully ✔\n");
            }

            // Setup delegate notifications
            OrderService service = new OrderService();
            service.StatusChanged += NotificationHandlers.NotifyCustomer;
            service.StatusChanged += NotificationHandlers.NotifyLogistics;

            // Process order stat uses
            foreach (Order order in orders)
            {
                try
                {
                    service.UpdateStatus(order, OrderStatus.Paid);
                    service.UpdateStatus(order, OrderStatus.Packed);
                    service.UpdateStatus(order, OrderStatus.Shipped);
                    service.UpdateStatus(order, OrderStatus.Delivered);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Order {order.Id}: {ex.Message}");
                }
            }

            // Print final report
            ReportService report = new ReportService();
            Console.WriteLine("\n===== FINAL ORDER SUMMARY =====");

            foreach (Order order in orders)
            {
                report.PrintOrderReport(order);
            }

            Console.ReadKey();
        }
    }
}
