using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    public class Order
    {
        public const int QUANTITY_LIMT = 3;

        private int id;     public int Id { get { return id; } set { id = value; } }
        public Location Location { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public Product Prod { get; set; }
        public int Qt { get; set; }
        public List<DbTuple<Product, int, Order>> Products { get; set; } = new List<DbTuple<Product, int, Order>>();

        public Order() {
            this.OrderDate = new DateTime();
        }
        public Order(Location location,
            Customer customer,
            DateTime orderDate,
            List<DbTuple<Product, int, Order>> products)
        {
            Location = location;
            Customer = customer;
            OrderDate = orderDate;
            Products = products;
        }

        
        // Displays the details of the order
        public void DisplayDetails()
        {
            // Location number
            Console.WriteLine($"location No. : {Location.Number}");
            // Customer first and last name
            Console.WriteLine($"Customer name : {Customer.FirstName} {Customer.LastName}");
            // Order placement date
            Console.WriteLine($"Date: {OrderDate}");

            // Iterate over the products in the current request and display their names
            Products.ForEach(product =>
            {
                Console.WriteLine($"Prodcut: {product.Item1.Name} | Quantity: {product.Item2}");
            });
        }

        // Places an order to the provided location after confirming the order can be fulfilled 
        public void PlaceOrderToLocation()
        {
            if (ConfirmOrder())
                Location.AddOrder(this);
        }


        // Confirms the order can be fulfilled
        public bool ConfirmOrder()
        {
            // Check if the order's quantity exceeds the limit
            if (Products.Where(p => p.Item2 > QUANTITY_LIMT).Any())
                return false;
            // Check if the location can fulfill the order
            return Location.ValidateOrder(Products);
        }

    }
}
