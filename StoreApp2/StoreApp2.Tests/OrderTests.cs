using System;
using StoreApp;
using Xunit;

namespace StoreApp2.Tests
{
    public class OrderTests
    {
        //Fixed(Order.cs line 22).  new DateTime() returns the default value (midnight 1/1/0001) vs. 'DateTime.Now'
        [Fact]
        public void CreatingANewOrderObject_setsOrderDateTimeToBeDefaultDateTime()
        {
            Order order = new Order();

            
            DateTime expectedResult = DateTime.Now;

            Assert.Equal(expectedResult, order.OrderDate);
        }
    }
}