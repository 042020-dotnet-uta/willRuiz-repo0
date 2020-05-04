using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    //Holds Proucts that make up the Inventory for the Store + how many products are currently avaiable
    public class Inventory
    {
        public int Id { get; set; }
        //Inventory needs x amount of each product...held as a value for (K:V)
        //Each new Product is held as an entry to this dictionary as a Key
        //Each Key has a value that is being passed below  
        private Dictionary<Product, int> products = new Dictionary<Product, int>()
        {
            //products.Add(K:V)
            { new Product("A"), 5 },    //Each Product is passed Name to initialize + add as Key in "product" Dictionary 
            { new Product("B"), 5 },    //Each K:V value is being held in Dictionary as teh value for that Key 
            { new Product("C"), 5 },
        };

        public Inventory() { }

        //Checks if the inventory on hand is >= what is being asked for
        public bool CheckAvailability(Product product, int count)
        {                                                                   //output available stock of that product ... compares against what we passed
            return products[products.Keys.Where(k => k.Name == product.Name.ToUpper()).FirstOrDefault()] >= count;
        }

             
        // Handles subtracting the products's quantity from the inventory
        
        public void HandleProduct(Product product, int quantity)
        {                                  //compare products name in Dictionary (A,B,C) to passed product.Name (A,B,C)
                                          //.FirstOrDefault() outputs the matched A=A k:value (default to 5) 
                                         //5- the passed "quantity"
                                        //Dictionary "products" k:value is udated with new quantity for that product
            products[products.Keys.Where(k => k.Name == product.Name.ToUpper()).FirstOrDefault()] -= quantity;
           
            
        }
        #region working
        public void AddProduct(Product product, int count)
        {
            products.Add(product, count);
        }

        // Handles subtracting the order's quantity from the inventory

        public void HandleOrder(Order order)
        {
            foreach (var productOrder in order.Products)
            {
                HandleProduct(productOrder.Item1, productOrder.Item2);
            }
        }
        #endregion
    }
}
