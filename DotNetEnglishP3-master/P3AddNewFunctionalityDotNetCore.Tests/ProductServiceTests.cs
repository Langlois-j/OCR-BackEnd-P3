using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Localization;
using Moq;
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
        //ProductService LocalProductService = new ProductService(ProductServiceTests.ProductRepositoryMock.Object,
        //    ProductServiceTests.OrderRepositoryMock.Object, ProductServiceTests.CartMock.Object,
        //    ProductServiceTests.LocalizerMock.Object);  

        //ProductViewModel TestProduct= new ProductViewModel
        //{
        //    Id = 1,
        //    Name = "Test Product",
        //    Price = "10.0",
        //    Stock = "100",
        //    Description = "This is a test product",
        //    Details = "Test details"
        //};
        //private object _localizer;



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
            // Arrange
            Cart LocalCart = new Cart();
            //a traiter en mok Pour connection
            //ProductRepository LocalProductRepo = new ProductRepository();
            //OrderRepository LocalOrderRepo = new OrderRepository();

            var OrderRepo = new Mock<IOrderRepository>();
            var mockLocalizer = new Mock<Microsoft.Extensions.Localization.IStringLocalizer<ProductService>>();

            var expectedProduct = new Product
            {
                Id = 1,
                Name = "Test Product",
                Description = "Description",
                Details = "Details",
                Price = 10.0,
                Quantity = 100
            };
            
            //mockCart.AddItem(expectedProduct, 1);
            //mockCart.Setup(r => r.GetProductById(1)).Returns(expectedProduct);

            var service = new ProductService(LocalCart,null, null, mockLocalizer.Object);
            //ProductService(ICart cart, IProductRepository productRepository,IOrderRepository orderRepository, IStringLocalizer < ProductService > localizer)
            // Act
            var result = service.GetProductById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedProduct.Id, result.Id);
        }
        [Fact]
        public void CkeckProduct_ReturnMissingName()
        {
            // Arrange

            //ProductViewModel LocalProduct = TestProduct;
            //    LocalProduct.Name = "";

            // Act
          //  List<string> errors = Productservice.CheckProductModelErrors(LocalProduct);

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
        public void AddProduct_ReturnNewProduct()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
        public void RemoveProduct_ReturnLessProducte()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
        public void UpdateProduct_ReturnNewQuantity()
        {
            // Arrange


            // Act


            // Assert
            Assert.Equal(1, 1);
        }
    }
}