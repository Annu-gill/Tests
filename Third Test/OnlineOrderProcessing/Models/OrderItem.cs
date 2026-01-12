namespace OnlineOrderProcessing.Models
{
    /// <summary>
    /// OrderItem represents a product with quantity inside an order.
    /// Demonstrates COMPOSITION (Order has OrderItems).
    /// </summary>
    public class OrderItem
    {
        public Product Product { get; }
        public int Quantity { get; }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        // Calculates total price for this item
        public decimal GetTotal()
        {
            return Product.Price * Quantity;
        }
    }
}
