using Microsoft.EntityFrameworkCore;
using Xunit;
using P3AddNewFunctionalityDotNetCore.Models;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;
using P3AddNewFunctionalityDotNetCore.Models.Entities;
using P3AddNewFunctionalityDotNetCore.Data;
using System.Linq;



namespace P3AddNewFunctionalityDotNetCore.Tests
{
    public class ProductServiceTestsIntegration
    {
        //Contexte propre à chaque test
        private P3Referential GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<P3Referential>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString()) // DB unique par test
                .Options;
            return new P3Referential(options, null);
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
           
            // Gestion du produit
            var testProduct = new ProductViewModel
            {
                Id = 0,
                Name = "Produit Test",
                Description = "Description",
                Details = "Detail",
                Stock = "10",
                Price = "20",
            };
            // Act
            service.SaveProduct(testProduct);

            // Assert
            var product = context.Product.FirstOrDefault(p=> p.Name == testProduct.Name);
            Assert.NotNull(product);
            Assert.Equal(10, product.Quantity);
            Assert.Equal(20, product.Price);
            //netoyage de la base
            context.Database.EnsureDeleted();
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
            //Gestion du Produit
            var myproduct = new Product
            {
                Name = "Produit Test",
                Description = "Description",
                Details = "Detail",
                Quantity = 10,
                Price = 20
            };
            context.Product.Add(myproduct);
            context.SaveChanges();//maj des ID

            // Act

            service.DeleteProduct(myproduct.Id);
            // Assert
            var product = context.Product.FirstOrDefault(p => p.Name == myproduct.Name);
            Assert.Null(product);
            //netoyage de la base
            context.Database.EnsureDeleted();
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
            int start = 15;
            int remove = 5;


            //Gestion du Produit
            var myproduct = new Product
            {
                Name = "Produit Test",
                Description = "Description",
                Details = "Detail",
                Quantity = start,
                Price = 20
            };
            context.Product.Add(myproduct);
            context.SaveChanges();//maj des ID
            cart.AddItem(myproduct, remove);

            // Act
            service.UpdateProductQuantities();

            // Assert
            var product = context.Product.FirstOrDefault(p => p.Id == myproduct.Id);
            Assert.NotNull(product);
            Assert.Equal(start - remove, product.Quantity);

            //netoyage de la base
            context.Database.EnsureDeleted();
        }

    }
}