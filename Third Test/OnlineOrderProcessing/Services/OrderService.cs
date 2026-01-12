using OnlineOrderProcessing.Models;

namespace OnlineOrderProcessing.Services
{
    /// <summary>
    /// Delegate declaration for order status change notifications.
    /// </summary>
    
    /// <param name="order"></param>
    /// <param name="oldStatus"></param>
    /// <param name="newStatus"></param>
    public delegate void OrderStatusChangedHandler(Order order, OrderStatus oldStatus, OrderStatus newStatus);
    /// <summary>
    /// Handles order-related operations.
    /// Separates business logic from UI.
    /// </summary>
    public class OrderService
    {
        // Multicast delegate
        public OrderStatusChangedHandler StatusChanged;

        // Updates order status and triggers notifications
        public void UpdateStatus(Order order, OrderStatus newStatus)
        {
            OrderStatus oldStatus = order.Status;
            order.ChangeStatus(newStatus);

            // Notify to all subscribers
            StatusChanged?.Invoke(order, oldStatus, newStatus);
        }
    }
}
