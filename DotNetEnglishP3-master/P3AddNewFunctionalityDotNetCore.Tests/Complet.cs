using P3AddNewFunctionalityDotNetCore.Models;
using P3AddNewFunctionalityDotNetCore.Models.Entities;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using Xunit;

namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class ProductServiceTests
    {
        private readonly ProductService _service;
        /// <summary>
        /// Take this test method as a template to write your test method.
        /// A test method must check if a definite method does its job:
        /// returns an expected value from a particular set of parameters
        /// </summary>
        [Fact]
        public void ExampleMethod()
        {
            // Arrange
         
            
            // Act


            // Assert
            Assert.Equal(1, 1);
        }
        // TODO write test methods to ensure a correct coverage of all possibilities
        [Fact] // Test la recherche d'un produit par son ID
        public void GetProductById()
        {
            // Arrange

            // Act

            // Assert
            Assert.Equal(1, 1);
        }
        [Fact] // Test la récupération de tous les produits
        public void GetAllProduct()
        {
            // Arrange

            // Act

            // Assert
            Assert.Equal(1, 1);
        }

    }
}