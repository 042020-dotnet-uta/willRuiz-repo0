﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp
{
    class Program
    {

        static void Main(string[] args)
        {
            OrderPrompt orderPrompt = new OrderPrompt();    
            while (orderPrompt.Prompt()){ }

            CustomersCollection c = new CustomersCollection();

            c.GetCustomerByName("John", "Wall");

            Console.WriteLine(); Console.ReadLine();
            

        }
    }
}