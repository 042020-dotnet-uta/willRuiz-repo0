using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreApp
{
    //Each Location instance must have its own store number and inventory of available products
    public class Location
    {
        private int id;     public int Id { get { return id; } set { id = value; } }
        public int Number { get; set; }
        private List<Order> orders = new List<Order>();     //Holds 1+ Orders as input from User (Order for Product A vs. Product B or multiple)
        private Inventory inventory = new Inventory();      //Each Location has Inventory (creates Procucts held by the store + inventory count of each Product)

        public Location() { }
        public Location(int number, Inventory inventory = null) //Each store has its own Store number + its Inventory of Products + quantities available
        {
            Number = number;    
            this.inventory = inventory ?? this.inventory; //?? NULL coalescing operator ...return 1st non-null value
        }


        //Add the order from the customer (basically a pass through method..give user inputs to Inventory...)
        public void AddProductOrder(Product product, int quantity)
        {
            inventory.HandleProduct(product, quantity);
        }

        // Checks if the order's quantity doesn't exceed the inventory

        public bool ValidateOrder(List<DbTuple<Product, int, Order>> productsOrder)
        {
            foreach (var productOrder in productsOrder)
            {
                if (!ValidateProduct(productOrder.Item1, productOrder.Item2))
                    return false;
            }
            return true;
        }

        // Checks if the prodcuts quantity doesn't exceed the inventory
        //Pass through method that gives user inputs to Inventory to make sure we have enough to fill the order

        public bool ValidateProduct(Product product, int quantity)
        {
            return inventory.CheckAvailability(product, quantity);
        }

#region working
        /// Adds an order to the location
        public void AddOrder(Order order)
        {
            orders.Add(order);
            inventory.HandleOrder(order);
        }

        
        // Displays all the orders made to this location
        public void DisplayOrdersHistory()
        {
            orders.ForEach(order =>
            {
                order.DisplayDetails();
            });
        }

#endregion





    }
}