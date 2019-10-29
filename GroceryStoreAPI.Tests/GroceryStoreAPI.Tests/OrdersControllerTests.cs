using FluentAssertions;
using GroceryStoreAPI.Controllers;
using System;
using System.Linq;
using Xunit;

namespace GroceryStoreAPI.Tests
{
    public class OrdersControllerTests
    {
        private OrdersController _ordersController;

        public OrdersControllerTests()
        {
            _ordersController = new OrdersController(new Repository.Repository());
        }

        // list all orders
        [Fact]
        public void Get_All()
        {
            // act
            var result = _ordersController.Get();

            // asset
            result.Count().Should().Be(1);
        }

        // retrieve an order
        [Fact]
        public void Get_Specific()
        {
            // act
            var result = _ordersController.Get(1);

            // asset
            result.ID.Should().Be(1);
        }

        // list all orders for a given date
        [Fact]
        public void Get_By_Date()
        {
            // act
            var result = _ordersController.GetByDate(DateTime.Now);

            // asset
            result.Count().Should().Be(1);
        }

        // list all orders for a customer
        [Fact]
        public void Get_By_Customer()
        {
            // act
            var result = _ordersController.GetByCustomerID(1);

            // asset
            result.Count().Should().Be(1);
        }
    }
}
