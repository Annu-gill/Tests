namespace OnlineOrderProcessing.Models
{
    /// <summary>
    /// Product represents items available for purchase.
    /// Used inside OrderItem (composition).
    /// </summary>
    public class Product
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
