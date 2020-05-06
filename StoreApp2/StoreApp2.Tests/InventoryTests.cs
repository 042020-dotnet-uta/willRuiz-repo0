using System;
using StoreApp;
using Xunit;

namespace StoreApp2.Tests
{
    public class InventoryTests
    {
        [Fact]
        public void CheckAvailability_OneItemRequiredAndProductIsAvailable_ReturnsTrue()
        {
            Inventory inventory = new Inventory();
            Product product = new Product("NewProduct A");
            inventory.AddProduct(product, 1);

            bool result = inventory.CheckAvailability(product, 1);

            Assert.True(result);    //Check even inventory
        }

        [Fact]
        public void CheckAvailability_TwoItemsRequiredAndEnoughUnitsOfTheProductAreAvailable_ReturnsTrue()
        {
            Inventory inventory = new Inventory();
            Product product = new Product("PRODUCT1");
            inventory.AddProduct(product, 10);

            bool result = inventory.CheckAvailability(product, 2);

            Assert.True(result);    //check surplus Inventory
        }

        [Fact]
        public void CheckAvailability_TwoItemsRequiredButNotEnoughUnitsOfTheProductAreAvailable_ReturnsFalse()
        {
            Inventory inventory = new Inventory();
            Product product = new Product("PRODUCT1");
            inventory.AddProduct(product, 1);

            bool result = inventory.CheckAvailability(product, 2);

            Assert.False(result);   //check when lacking enough Inventory to fulfill the order
        }
    }
}