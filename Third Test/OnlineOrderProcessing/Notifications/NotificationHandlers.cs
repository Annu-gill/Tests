using System;
using OnlineOrderProcessing.Models;

namespace OnlineOrderProcessing.Notifications
{
    /// <summary>
    /// Contains notification logic.
    /// Uses DELEGATES to notify multiple subscribers.
    /// </summary>
    public static class NotificationHandlers
    {
        // Customer notification
        public static void NotifyCustomer(Order order, OrderStatus oldStatus, OrderStatus newStatus)
        {
            Console.WriteLine($"[Customer] Order {order.Id} status changed from {oldStatus} to {newStatus}");
        }

        // Logistics notification
        public static void NotifyLogistics(Order order, OrderStatus oldStatus, OrderStatus newStatus)
        {
            if (newStatus == OrderStatus.Shipped)
            {
                Console.WriteLine($"[Logistics] Order {order.Id} is ready for delivery");
            }
        }
    }
}
