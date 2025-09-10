using Microsoft.EntityFrameworkCore;
using Xunit;
using P3AddNewFunctionalityDotNetCore.Models;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;
using P3AddNewFunctionalityDotNetCore.Models.Entities;
using P3AddNewFunctionalityDotNetCore.Data;



namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class ProductServiceInMemoryTests
    {
        //Exemple d'utilisation d'une base en mémoire pour les tests unitaires

        //private ApplicationDbContext GetInMemoryDbContext()
        //{
        //    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        //        .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString()) // DB unique par test
        //        .Options;
        //    return new ApplicationDbContext(options);
        //}
        private P3Referential GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<P3Referential>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString()) // DB unique par test
                .Options;
            return new P3Referential(options, null);
        }

        private ProductViewModel GetTestProductViewModel()
        {
            return new ProductViewModel
            {
                Id = 0,
                Name = "Produit Test",
                Description = "Description",
                Details = "Detail",
                Stock = "10",
                Price = "20",
            };
        }

        [Fact]
        public void ProductAddData()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            var repo = new ProductRepository(context);
            var orderRepo = new OrderRepository(context);
            var cart = new Cart();
            var service = new ProductService(cart, repo, orderRepo, null);
            var testProduct = GetTestProductViewModel();

            // Act
            service.SaveProduct(testProduct);

            // Assert
            var product = service.GetProduct(testProduct.Id);
            Assert.NotNull(product);
            Assert.Equal(10, product.Quantity);
            Assert.Equal(20, product.Price);
            //netoyage de la base
            service.DeleteProduct(testProduct.Id);
        }
        [Fact]
        public void ProductDeleteData()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            var repo = new ProductRepository(context);
            var orderRepo = new OrderRepository(context);
            var cart = new Cart();
            var service = new ProductService(cart, repo, orderRepo, null);
            var testProduct = GetTestProductViewModel();

            //ajoute du produit a supprimer
            service.SaveProduct(testProduct);
            // Act

            service.DeleteProduct(testProduct.Id);
            // Assert
            var product = context.Products.FirstOrDefault(p => p.Name == "Produit Test");
            Assert.Null(product);
          
        }
                [Fact]
        public void ProductUpdateQuantitiesData()
        {
            // Arrange
            using var context = GetInMemoryDbContext();
            var repo = new ProductRepository(context);
            var orderRepo = new OrderRepository(context);
            var cart = new Cart();
            var service = new ProductService(cart, repo, orderRepo, null);
            var testProduct = GetTestProductViewModel();

            //ajoute du produit a Modifier
            service.SaveProduct(testProduct);
            //modifiaction des quantitée
            testProduct.Stock = "1";

            // Act

            service.UpdateProductQuantities(testProduct);
            // Assert
            var product = context.Products.FirstOrDefault(p => p.Name == "Produit Test");
            Assert.Null(product);
          
            //netoyage de la base
            service.DeleteProduct(testProduct.Id);
        }

    }
}