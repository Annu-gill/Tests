using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineOrderProcessing.Models
{
    /// <summary>
    /// Order is the core business entity.
    /// It manages items, total calculation, and status transitions.
    /// Demonstrates encapsulation, composition, and business rule validation.
    /// </summary>

    public class Order
    {
        public int Id { get; }
        public Customer Customer { get; }
        public List<OrderItem> Items { get; }
        public OrderStatus Status { get; private set; }
        public List<OrderStatusLog> StatusHistory { get; }

        public Order(int id, Customer customer)
        {
            Id = id;
            Customer = customer;
            Items = new List<OrderItem>();
            Status = OrderStatus.Created;
            StatusHistory = new List<OrderStatusLog>();
        }

        // Adds an item to the order
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        // Calculates order total
        public decimal CalculateTotal()
        {
            return Items.Sum(i => i.GetTotal());
        }

        /// <summary>
        /// Handles order status changes.
        /// Validates business rules before allowing transitions.
        /// </summary>
        /// <param name="newStatus"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void ChangeStatus(OrderStatus newStatus)
        {
            if (Status == OrderStatus.Cancelled)
                throw new InvalidOperationException("Cancelled order cannot change status.");

            if (newStatus == OrderStatus.Paid && Status != OrderStatus.Created)
                throw new InvalidOperationException("Order must be Created before Paid.");

            if (newStatus == OrderStatus.Packed && Status != OrderStatus.Paid)
                throw new InvalidOperationException("Order must be Paid before Packed.");

            if (newStatus == OrderStatus.Shipped && Status != OrderStatus.Packed)
                throw new InvalidOperationException("Order must be Packed before Shipped.");

            if (newStatus == OrderStatus.Delivered && Status != OrderStatus.Shipped)
                throw new InvalidOperationException("Order must be Shipped before Delivered.");

            // Store history
            StatusHistory.Add(new OrderStatusLog(Status, newStatus));

            // Update status
            Status = newStatus;
        }
    }
}
