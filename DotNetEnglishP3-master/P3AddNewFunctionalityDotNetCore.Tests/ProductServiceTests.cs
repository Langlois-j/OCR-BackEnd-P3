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
            Stock = "",
            Price = "",
        };
       // private static ResourceManager resourceManager = new ResourceManager("P3.Resources.Models.Services.ProductService", Assembly.GetExecutingAssembly());
        /// <summary>
        /// Take this test method as a template to write your test method.
        /// A test method must check if a definite method does its job:
        /// returns an expected value from a particular set of parameters
        /// </summary>

        // [Fact]
        //public void GetProductById_ReturnProduct()
        //{
        //    //Arrange

        //   var expectedProduct = new Product
        //   {
        //       Id = 1,
        //       Name = "Test Product",
        //       Description = "Description",
        //       Details = "Details",
        //       Price = 10.0,
        //       Quantity = 100
        //   };

        //    _mockProductRepo.Setup(r => r.GetAllProducts()).Returns(new List<Product> { expectedProduct });
        //    var service = new ProductService(_mockCart.Object, _mockProductRepo.Object, _mockOrderRepo.Object, _mockLocalizer.Object);

        //    // Act
        //    var result = service.GetProductById(expectedProduct.Id);
        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(expectedProduct.Id, result.Id);
        //}
        [Fact]
        public void CheckProductModelErrors_ReturnsError_WhenNameIsMissing()
        {
            // Arrange
        
          _invalidProduct.Name = null; // Simulate missing name
    
            // Act
           var results = new List<ValidationResult>();
           var context = new ValidationContext(_invalidProduct);

            // Assert
            Validator.TryValidateObject(_invalidProduct, context, results, true);
        }
         [Fact]
        public void CheckProductModelErrors_ReturnsError_WhenPriceNotANumber()
        {
            // Arrange

            //var service = new ProductService(_mockCart.Object, _mockProductRepo.Object, _mockOrderRepo.Object, _mockLocalizer.Object);
            _invalidProduct.Price = "Price"; // Simulate missing name

            // Act
            var results = new List<ValidationResult>();
            var context = new ValidationContext(_invalidProduct);

            // Assert
            Validator.TryValidateObject(_invalidProduct, context, results, true);
        }
         [Fact]
        public void CheckProductModelErrors_ReturnsError_WhenPriceNotGreaterThanZero()
        {
            // Arrange
             _invalidProduct.Price = "0"; // Simulate missing name

            // Act
            var results = new List<ValidationResult>();
            var context = new ValidationContext(_invalidProduct);

            // Assert
            Validator.TryValidateObject(_invalidProduct, context, results, true);
        }
         [Fact]
        public void CheckProductModelErrors_ReturnsError_WhenMissingStock()
        {
            // Arrange
             _invalidProduct.Stock = null; // Simulate missing name
            // Act
            var results = new List<ValidationResult>();
            var context = new ValidationContext(_invalidProduct);

            // Assert
            Validator.TryValidateObject(_invalidProduct, context, results, true);
        }

          [Fact]
        public void CheckProductModelErrors_ReturnsError_WhenStockNotGreaterThanZero()
        {
            // Arrange
             _invalidProduct.Stock = "-1"; // Simulate missing name
            // Act
            var results = new List<ValidationResult>();
            var context = new ValidationContext(_invalidProduct);

            // Assert
            Validator.TryValidateObject(_invalidProduct, context, results, true);
        }

          [Fact]
        public void CheckProductModelErrors_ReturnsError_WhenStockNotAnInteger()
        {
            // Arrange
            _invalidProduct.Stock = "null"; // Simulate missing name
            // Act
            var results = new List<ValidationResult>();
            var context = new ValidationContext(_invalidProduct);

            // Assert
            Validator.TryValidateObject(_invalidProduct, context, results, true);
        }

         [Fact]
        public void CheckProductModelErrors_ReturnsError_WhenPriceIsMissing()
        {
            // Arrange
            _invalidProduct.Price = null; // Simulate missing name

            // Act
            var results = new List<ValidationResult>();
            var context = new ValidationContext(_invalidProduct);

            // Assert
            Validator.TryValidateObject(_invalidProduct, context, results, true);
        }

        //[Fact]
        //public void SaveProduct_ShouldCallRepositoryWithCorrectProduct()
        //{
        //    // Arrange
        //    var productViewModel = new ProductViewModel
        //    {
        //        Id = 92,
        //        Name = "Produit SaveTest",
        //        Description = "Description test",
        //        Details = "Détails test",
        //        Stock = "15",
        //        Price = "18"//Valeur entiere pour simplifier le test vis à vis de la culture
        //    };
        //    //pour le prix aevx la culture soit Forcer la culture ,et , Pour FR et . pour EN  sois mettre en fonction de la culture par defaut
        //    var service = new ProductService(_mockCart.Object, _mockProductRepo.Object, _mockOrderRepo.Object, _mockLocalizer.Object);
        //    // Act
        //    service.SaveProduct(productViewModel);
        //    // Assert
        //    //test l'ajout d'un produit dans le panier
        //    _mockProductRepo.Verify(r => r.SaveProduct(It.Is<Product>(p =>
        //        p.Name == productViewModel.Name &&
        //        p.Description == productViewModel.Description &&
        //        p.Details == productViewModel.Details &&
        //        p.Quantity == int.Parse(productViewModel.Stock) &&
        //        p.Price == double.Parse(productViewModel.Price)
        //    )), Times.Once);
        //}
        //[Fact]
        //public void DeleteProduct_ShouldRemoveProductFromCartAndRepository()
        //{
        //    // Arrange
        //    int productId = 90;
        //    var product = new Product { Id = productId, Name = "DeleteTest" };
        //    var service = new Mock<ProductService>(_mockCart.Object, _mockProductRepo.Object, _mockOrderRepo.Object, _mockLocalizer.Object);

        //    // Simulation le repo pour retourner le produit attendu
        //    _mockProductRepo.Setup(r => r.GetAllProducts()).Returns(new List<Product> { product });
        //    // Act
        //    service.Object.DeleteProduct(productId);
        //    // Assert
        //    _mockCart.Verify(c => c.RemoveLine(product), Times.Once);// vérifie si l'appel à été fait au moins une fois et qu'une seulle fois
        //    _mockProductRepo.Verify(r => r.DeleteProduct(productId), Times.Once);// vérifie si l'appel à été fait au moins une fois et qu'une seulle fois
        //}
        //[Fact]
        //public void UpdateProductQuantities_ShouldCallUpdateProductStocksForEachCartLine()
        //{
        //    // Arrange
        //    int productQuantity = 8;

        //    var product = new Product { Id = 91, Name = "Product 8" };

        //    var cart = new Cart();
        //    cart.AddItem(product, productQuantity);

        //    var service = new ProductService(cart, _mockProductRepo.Object, _mockOrderRepo.Object, _mockLocalizer.Object);
        //    // Act
        //    service.UpdateProductQuantities();
        //    // Assert
        //    _mockProductRepo.Verify(r => r.UpdateProductStocks(product.Id, productQuantity), Times.Once);// vérifie si l'appel à été fait au moins une fois et qu'une seulle fois

        //}
    }
}