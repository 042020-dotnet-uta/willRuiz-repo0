using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    public class Customer
    {
        private int id;     public int Id { get { return id; } set { id = value; } }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        


        public Customer() { }
        public Customer(string firstName, string lastName )
        {
            FirstName = firstName;
            LastName = lastName;    
        }

        public Customer(string firstName, string lastName, string addess)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = Address;
        }

        

            /// Displays all of the customer's orders
            public void DisplayOrdersHistory()
        {
            Orders.ForEach(order =>
            {
                order.DisplayDetails();
            });
        }

    }
}
