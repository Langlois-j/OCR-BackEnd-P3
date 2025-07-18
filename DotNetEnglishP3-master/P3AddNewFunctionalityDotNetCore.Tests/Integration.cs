using P3AddNewFunctionalityDotNetCore.Models;
using P3AddNewFunctionalityDotNetCore.Models.Entities;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using Xunit;

namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class ProductRepositoryTests
    {

        [Fact] // Test l'ajout d'un produit
        public void SaveProductTest()
        {
            // Arrange

            // Act

            // Assert
            Assert.Equal(1, 1);
        }
        [Fact] // Test la modification d'un produit  existant
        public void UpdateProductTest()
        {
            // Arrange

            // Act

            // Assert
            Assert.Equal(1, 1);
        }
        [Fact] // Test la Suppression d'un produit  existant
        public void DeleteProductTest()
        {
            // Arrange

            // Act

            // Assert
            Assert.Equal(1, 1);
        }
        [Fact] // Test la présence d'un produit dans la base de données
        public void GetProductTest()
        {
            // Arrange

            // Act

            // Assert
            Assert.Equal(1, 1);
        }
    }
}