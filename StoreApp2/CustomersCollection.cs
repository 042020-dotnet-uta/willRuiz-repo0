using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    public class CustomersCollection
    {
        public Store_DbContext db = new Store_DbContext();
        Customer newCustomer = new Customer();
        public static List<Customer> Customers { get; set; } = new List<Customer>();


        // Adds a new costumer to Customers list

        public void AddCustomer(string firstName, string lastName, int id)
        {
            newCustomer.FirstName = firstName;
            newCustomer.LastName = lastName;
            newCustomer.Id =id;
            AddToDatabase(newCustomer);
             Customers.Add(new Customer(firstName, lastName));
        }

        public void AddCustomer(string firstName, string lastName)
        {
            newCustomer.FirstName = firstName;
            newCustomer.LastName = lastName;
            //newCustomer.Id =id;
            AddToDatabase(newCustomer);
            Customers.Add(new Customer(firstName, lastName));
        }

        public void AddToDatabase(Customer newCustomer)
        {
            db.Add(newCustomer);
            db.SaveChanges();
        }


        // Retrieve an array of customers by their first and last names 

        public void GetCustomerByName(string firstName, string lastName)
        {
            var custArr =  Customers.Where(customer => customer.FirstName == firstName && 
            customer.LastName == lastName).ToArray();

            Array.ForEach(custArr, c => Console.WriteLine("The Customer is: " + c.ToString() )); 
        }
 


    }
}
