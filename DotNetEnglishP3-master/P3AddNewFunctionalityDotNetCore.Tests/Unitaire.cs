using P3AddNewFunctionalityDotNetCore.Models;
using P3AddNewFunctionalityDotNetCore.Models.Entities;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;
using Xunit;
//using P3AddNewFunctionalityDotNetCore.Models.Entities.Order;
//using P3AddNewFunctionalityDotNetCore.Models.Entities.OrderLine;
//using P3AddNewFunctionalityDotNetCore.Models.Entities.Product;
namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class OrderTests
    {
        /// <summary>
 //test Les méthodes de validation du panier
        /// </summary>
        [Fact]//Test l'absence d'une adresse
        public void SetAdressTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
        [Fact]//Test l'absence d'une City
        public void SetCityTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
        [Fact]//Test l'absence d'une Country
        public void SetCountryTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
        [Fact]//Test l'absence d'un Name
        public void SetNameTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
        [Fact]//Test l'absence d'un Zip
        public void SetZipTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
        [Fact]//Test l'absence d'élément dasn le panier
        public void SetOrderLineTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
    }
    public class OrderLineTests
    {
        /// <summary>
 //test Les méthodes du panier
        /// </summary>
        [Fact]//Test l'absence d'une adresse
        public void NewOderLineTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
    }
    public class ProductTests
    {
        /// <summary>
 //test Les méthodes des Produit
        /// </summary>
        [Fact]//Test l'absence d'une Description
        public void SetDescriptionTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
        [Fact]//Test l'absence d'un no
        public void SetNameTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
        [Fact]//Test l'absence d'un Prix
        public void SetPriceTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
        [Fact]//Test l'absence d'une Quantitée
        public void SetQuantityTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
        [Fact]//Test une Quantitée non numérique
        public void StringQuantityTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
        [Fact]//Test une Quantitée negative
        public void NegativeQuantityTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
        [Fact]//Test un prix negative
        public void NegativePriceTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
        [Fact]//Test un prix non numérique
        public void StringPriceTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
    }
    public class MemberShipTests
    {
       
 
        [Fact]//Test la connextion administrateur
        public void ConnectionTestTest()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
      
    }