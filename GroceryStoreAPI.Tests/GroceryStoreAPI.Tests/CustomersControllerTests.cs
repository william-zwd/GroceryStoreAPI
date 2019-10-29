using FluentAssertions;
using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Models;
using System.Linq;
using Xunit;

namespace GroceryStoreAPI.Tests
{
    public class CustomersControllerTests
    {
        private CustomersController _customersController;

        public CustomersControllerTests()
        {
            _customersController = new CustomersController(new Repository.Repository());
        }

        // list all customer
        [Fact]
        public void Get_All()
        {
            // act
            var result = _customersController.Get();

            // asset
            result.Count().Should().Be(3);
        }

        // retrieve a customer
        [Fact]
        public void Get_Specific()
        {
            // act
            var result = _customersController.Get(1);

            // asset
            result.ID.Should().Be(1);
        }

        // add a customer
        [Fact]
        public void Add()
        {
            // arrange
            var newCustomer = new Customer()
            {
                Name = "Abraham"
            };

            // act
            _customersController.Post(newCustomer);

            var result = _customersController.Get();

            // asset
            result.Count().Should().Be(4);
        }
    }
}
