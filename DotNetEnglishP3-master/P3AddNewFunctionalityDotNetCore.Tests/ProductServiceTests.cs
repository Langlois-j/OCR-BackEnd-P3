using Moq;
using P3AddNewFunctionalityDotNetCore.Models;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;
using P3AddNewFunctionalityDotNetCore.Resources.Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using Xunit;
namespace P3AddNewFunctionalityDotNetCore.Tests

{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockProductRepo;
        private readonly Mock<IOrderRepository> _mockOrderRepo;

        private readonly Mock<ICart> _mockCart;
        private readonly ProductViewModel _invalidProduct = new ProductViewModel

        {
            Id = 0,
            Name = "ProduitName",
            Description = "",
            Details = "",
            Stock = "1",
            Price = "1",
        };
        private static List<ValidationResult> ValidateModel(object model)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);

            Validator.TryValidateObject(model, context, results, true);

            return results;
        }

        [Fact]
        public void CheckProductModelErrors_ReturnsError_WhenNameIsMissing()
        {
            // Arrange

            _invalidProduct.Name = null; // Simulate missing name

            // Act
            var results = ValidateModel(_invalidProduct);

            // Assert
            Assert.Contains(results, v => v.ErrorMessage == ProductService.MissingName);
        }
        [Fact]
        public void CheckProductModelErrors_ReturnsError_WhenPriceNotANumber()
        {
            // Arrange
            _invalidProduct.Price = "Price";

            // Act
            var results = ValidateModel(_invalidProduct);

            // Assert
            Assert.Contains(results, v => v.ErrorMessage == ProductService.PriceNotANumber);
        }
         [Fact]
        public void CheckProductModelErrors_ReturnsError_WhenPriceNotGreaterThanZero()
        {
            // Arrange
             _invalidProduct.Price = "0";

            // Act
            var results = ValidateModel(_invalidProduct);

            // Assert
            Assert.Contains(results, v => v.ErrorMessage == ProductService.PriceNotGreaterThanZero);
        }
         [Fact]
        public void CheckProductModelErrors_ReturnsError_WhenMissingStock()
        {
            // Arrange
             _invalidProduct.Stock = null;
            // Act
            var results = ValidateModel(_invalidProduct);

            // Assert
            Assert.Contains(results, v => v.ErrorMessage == ProductService.MissingStock);
        }

          [Fact]
        public void CheckProductModelErrors_ReturnsError_WhenStockNotGreaterThanZero()
        {
            // Arrange
             _invalidProduct.Stock = "-1";
            // Act
            var results = ValidateModel(_invalidProduct);

            // Assert
            Assert.Contains(results, v => v.ErrorMessage == ProductService.StockNotGreaterThanZero);
        }

          [Fact]
        public void CheckProductModelErrors_ReturnsError_WhenStockNotAnInteger()
        {
            // Arrange
            _invalidProduct.Stock = "InvalideValue";
            // Act
            var results = ValidateModel(_invalidProduct);

            // Assert
            Assert.Contains(results, v => v.ErrorMessage == ProductService.StockNotAnInteger);
        }

         [Fact]
        public void CheckProductModelErrors_ReturnsError_WhenPriceIsMissing()
        {
            // Arrange
            _invalidProduct.Price = null;

            // Act
            var results = ValidateModel(_invalidProduct);

            // Assert
            Assert.Contains(results, v => v.ErrorMessage == ProductService.MissingPrice);
        }
    }
}