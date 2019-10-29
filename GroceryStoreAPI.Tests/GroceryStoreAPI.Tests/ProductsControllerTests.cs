using FluentAssertions;
using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Models;
using System.Linq;
using Xunit;

namespace GroceryStoreAPI.Tests
{
    public class ProductsControllerTests
    {
        private ProductsController _productsController;

        public ProductsControllerTests()
        {
            _productsController = new ProductsController(new Repository.Repository());
        }

        // list all products
        [Fact]
        public void Get_All()
        {
            // act
            var result = _productsController.Get();

            // asset
            result.Count().Should().Be(3);
        }

        // retrieve a product
        [Fact]
        public void Get_Specific()
        {
            // act
            var result = _productsController.Get(1);

            // asset
            result.ID.Should().Be(1);
        }

        // add a product
        [Fact]
        public void Add()
        {
            // arrange
            var newProduct = new Product()
            {
                Description = "Pear",
                Price = 0.65M,
            };

            // act
            _productsController.Post(newProduct);

            var result = _productsController.Get();

            // asset
            result.Count().Should().Be(4);
        }
    }
}
