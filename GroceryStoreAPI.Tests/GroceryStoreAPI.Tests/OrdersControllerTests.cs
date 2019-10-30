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

        [Fact]
        public void Get_OutOfRange_ReturnNull()
        {
            // act
            var result = _ordersController.Get(10);

            // asset
            result.Should().Be(null);
        }

        // list all orders for a given date
        [Fact]
        public void Get_By_Date()
        {
            // act
            var result = _ordersController.GetByDate(DateTime.Now.Date.ToString());

            // asset
            result.Count().Should().Be(1);
        }

        [Fact]
        public void Get_Yesterday_ReturnEmptySet()
        {
            // act
            var yesterday = DateTime.Today.AddDays(-1);
            var result = _ordersController.GetByDate(yesterday.Date.ToString());

            // asset
            result.Count().Should().Be(0);
        }

        // list all orders for a customer
        [Fact]
        public void Get_By_CustomerID()
        {
            // act
            var result = _ordersController.GetByCustomerID(1);

            // asset
            result.Count().Should().Be(1);
        }

        [Fact]
        public void Get_OutOfRange_CustomerID_ReturnEmptySet()
        {
            // act
            var result = _ordersController.GetByCustomerID(10);

            // asset
            result.Count().Should().Be(0);
        }
    }
}
