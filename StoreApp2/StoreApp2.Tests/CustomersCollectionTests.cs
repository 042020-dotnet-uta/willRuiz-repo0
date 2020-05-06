using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using StoreApp;
using Xunit;

namespace StoreApp2.Tests
{
    public class CustomersCollectionTests
    {
        [Fact]
        public void Check_AddCustomer_AddsCustomerToDatabase()
        {
			var options = new DbContextOptionsBuilder<Store_DbContext>()
			.UseInMemoryDatabase(databaseName: "CustomerDatabase")
			.Options;

			CustomersCollection customersCollection = new CustomersCollection();
			Customer newCustomer = new Customer();
			newCustomer.FirstName = "FirstName";
			newCustomer.LastName = "LastName";

			int customerRecordCount;

			using (var context = new Store_DbContext(options))
			{
				customersCollection.db = context;
				customersCollection.AddToDatabase(newCustomer);

				customerRecordCount = context.Customers.Count();
			}

			Assert.Equal(1, customerRecordCount);
		}
	}
}

//Installed Microsoft.EntityFrameworkCore.InMemory.3.1.3 NuGet package