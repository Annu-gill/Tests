namespace OnlineOrderProcessing.Models
{
    /// <summary>
    /// Enum representing fixed states of an order.
    /// Using enum improves readability and prevents invalid values.
    /// </summary>
    public enum OrderStatus
    {
        Created,
        Paid,
        Packed,
        Shipped,
        Delivered,
        Cancelled
    }
}
