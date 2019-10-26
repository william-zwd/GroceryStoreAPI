using FluentAssertions;
using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Models;
using System.Linq;
using Xunit;

namespace GroceryStoreAPI.Tests
{
    public class CustomersControllerTests
    {
        // list all customer
        [Fact]
        public void Get_All()
        {
            // arrange
            var controller = new CustomersController(new Repository.Repository());

            // act
            var result = controller.Get();

            // asset
            result.Count().Should().Be(3);
        }

        // retrieve a customer
        [Fact]
        public void Get_Specific()
        {
            // arrange
            var controller = new CustomersController(new Repository.Repository());

            // act
            var result = controller.Get(1);

            // asset
            result.ID.Should().Be(1);
        }

        // add a customer
        [Fact]
        public void Add()
        {
            // arrange
            var controller = new CustomersController(new Repository.Repository());
            var newCustomer = new Customer()
            {
                Name = "Abraham"
            };

            // act
            controller.Post(newCustomer);

            var result = controller.Get();

            // asset
            result.Count().Should().Be(4);
        }
    }
}
