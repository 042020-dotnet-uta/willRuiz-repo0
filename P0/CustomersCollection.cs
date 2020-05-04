using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    public class CustomersCollection
    {
        Store_DbContext db = new Store_DbContext();
        Customer newCustomer = new Customer();

        
        // Adds a new costumer to Customers list

        public void AddCustomer(string firstName, string lastName)
        {
            newCustomer.FirstName = firstName;
            newCustomer.LastName = lastName;
            //newCustomer.Id =id;
            db.Add(newCustomer);
            db.SaveChanges();
                //Customers.Add(new Customer(firstName, lastName));
        }

        //Class level Field Option: public static List<Customer> Customers { get; set; } = new List<Customer>();
        // Retrieve an array of customers by their first and last names 

        /*public static Customer[] GetCustomerByName(string firstName, string lastName)
        {
            return Customers.Where(customer => customer.FirstName == firstName && 
            customer.LastName == lastName).ToArray();
        }
        */
    }
}
