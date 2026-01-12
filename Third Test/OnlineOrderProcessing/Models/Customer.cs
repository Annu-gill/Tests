namespace OnlineOrderProcessing.Models
{    
     /// <summary>
     /// Customer class represents a buyer in the system.
     /// It demonstrates ENCAPSULATION by exposing only read-only properties.
     /// </summary>
    public class Customer
    {
        // Unique identifier of the customer
        public int Id { get; }

        // Name of the customer
        public string Name { get; }

        // Constructor initializes customer details
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
