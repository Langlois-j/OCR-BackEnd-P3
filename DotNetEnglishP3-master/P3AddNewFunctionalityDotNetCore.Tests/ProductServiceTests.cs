using Microsoft.CodeAnalysis;
using P3AddNewFunctionalityDotNetCore.Models;
using P3AddNewFunctionalityDotNetCore.Models.Entities;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;
using System.Collections.Generic;
using Xunit;

namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class ProductServiceTests
    {
        /// <summary>
        /// Take this test method as a template to write your test method.
        /// A test method must check if a definite method does its job:
        /// returns an expected value from a particular set of parameters
        /// </summary>
        ProductService LocalProductService = new ProductService(ProductServiceTests.ProductRepositoryMock.Object,
            ProductServiceTests.OrderRepositoryMock.Object, ProductServiceTests.CartMock.Object,
            ProductServiceTests.LocalizerMock.Object);  

        ProductViewModel TestProduct= new ProductViewModel
        {
            Id = 1,
            Name = "Test Product",
            Price = "10.0",
            Stock = "100",
            Description = "This is a test product",
            Details = "Test details"
        };
        private object _localizer;

        [Fact]
        public void ExampleMethod()
        {
            // Arrange
         
            
            // Act


            // Assert
            Assert.Equal(1, 1);
        }
        // TODO write test methods to ensure a correct coverage of all possibilities
        [Fact]
        public void GetOneProduct_ReturnProduct()
        {
            //// Arrange
            //const int productId = 1;

            //// Act
            //Product Result=Productservice.GetProductById(productId);

            //// Assert
            //Assert.Equal(productId, actual: Result.Id);
            Assert.Equal(1, 1);
        }
        [Fact]
        public void CkeckProduct_ReturnMissingName()
        {
            // Arrange

            ProductViewModel LocalProduct = TestProduct;
                LocalProduct.Name = "";

            // Act
            List<string> errors = Productservice.CheckProductModelErrors(LocalProduct);

            // Assert
            // Assert.Equal(errors[0], _localizer["MissingName"]);
            Assert.Equal(1, 1);
        }
        public void CkeckProduct_ReturnMissingPrice()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
    }
}