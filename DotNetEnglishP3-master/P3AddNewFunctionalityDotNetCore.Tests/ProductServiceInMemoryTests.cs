using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using P3AddNewFunctionalityDotNetCore.Models;
using P3AddNewFunctionalityDotNetCore.Models.Services;
using P3AddNewFunctionalityDotNetCore.Models.Repositories;
using P3AddNewFunctionalityDotNetCore.Models.ViewModels;




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
            var product = context.Products.FirstOrDefault(p => p.Name == "Produit Test");
            Assert.NotNull(product);
            Assert.Equal(10, product.Quantity);
            Assert.Equal(20, product.Price);
            service.DeleteProduct(testProduct.Id);
        }
    }
}