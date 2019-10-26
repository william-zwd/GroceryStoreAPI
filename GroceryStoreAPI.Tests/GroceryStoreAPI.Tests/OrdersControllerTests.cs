using FluentAssertions;
using GroceryStoreAPI.Controllers;
using System;
using System.Linq;
using Xunit;

namespace GroceryStoreAPI.Tests
{
    public class OrdersControllerTests
    {
        // list all orders
        [Fact]
        public void Get_All()
        {
            // arrange
            var controller = new OrdersController(new Repository.Repository());

            // act
            var result = controller.Get();

            // asset
            result.Count().Should().Be(1);
        }

        // retrieve an order
        [Fact]
        public void Get_Specific()
        {
            // arrange
            var controller = new OrdersController(new Repository.Repository());

            // act
            var result = controller.Get(1);

            // asset
            result.ID.Should().Be(1);
        }

        // list all orders for a given date
        [Fact]
        public void Get_By_Date()
        {
            // arrange
            var controller = new OrdersController(new Repository.Repository());

            // act
            var result = controller.GetByDate(DateTime.Now);

            // asset
            result.Count().Should().Be(1);
        }

        // list all orders for a customer
        [Fact]
        public void Get_By_Customer()
        {
            // arrange
            var controller = new OrdersController(new Repository.Repository());

            // act
            var result = controller.GetByCustomerID(1);

            // asset
            result.Count().Should().Be(1);
        }

    }
}
