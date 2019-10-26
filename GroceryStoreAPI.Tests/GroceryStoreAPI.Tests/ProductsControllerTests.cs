using FluentAssertions;
using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Models;
using System.Linq;
using Xunit;

namespace GroceryStoreAPI.Tests
{
    public class ProductsControllerTests
    {
        // list all products
        [Fact]
        public void Get_All()
        {
            // arrange
            var controller = new ProductsController(new Repository.Repository());

            // act
            var result = controller.Get();

            // asset
            result.Count().Should().Be(3);
        }

        // retrieve a product
        [Fact]
        public void Get_Specific()
        {
            // arrange
            var controller = new ProductsController(new Repository.Repository());

            // act
            var result = controller.Get(1);

            // asset
            result.ID.Should().Be(1);
        }

        // add a product
        [Fact]
        public void Add()
        {
            // arrange
            var controller = new ProductsController(new Repository.Repository());
            var newProduct = new Product()
            {
                Description = "Pear",
                Price = 0.65M,
            };

            // act
            controller.Post(newProduct);

            var result = controller.Get();

            // asset
            result.Count().Should().Be(4);
        }
    }
}
