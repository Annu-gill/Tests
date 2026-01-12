using System;

namespace OnlineOrderProcessing.Models
{
    /// <summary>
    /// Stores history of order status changes.
    /// Helps in tracking timeline of an order.
    /// </summary>
    public class OrderStatusLog
    {
        public OrderStatus OldStatus { get; }
        public OrderStatus NewStatus { get; }
        public DateTime ChangedOn { get; }

        public OrderStatusLog(OrderStatus oldStatus, OrderStatus newStatus)
        {
            OldStatus = oldStatus;
            NewStatus = newStatus;
            ChangedOn = DateTime.Now;
        }
    }
}
