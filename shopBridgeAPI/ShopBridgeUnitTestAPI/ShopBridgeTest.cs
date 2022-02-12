using NUnit.Framework;
using shopBridge.Infrastructure.Repository;
using shopBridge.Service;
using shopBridge.Controllers;
using Moq;
using Microsoft.EntityFrameworkCore;
using shopBridge.Model;
using shopBridge.Controllers;
using System.Collections.Generic;
using Xunit;
using System;
using System.Threading.Tasks;
using shopBridge.Service.Response;

namespace ShopBridgeUnitTestAPI
{
    public class ShopBridgeUnitTest
    {
        private Mock<IProductService> _mockproductSVC;

        public ShopBridgeUnitTest()
        {
            _mockproductSVC = new Mock<IProductService>();
        }
        [Test]
        public async Task GetProducts()
        {
            productController productController = new productController(_mockproductSVC.Object);
             _mockproductSVC.Setup(x => x.GetProduct()).Returns(GetProductsData());

            var data = productController.GetProduct();
            Assert.NotNull(data);
        }
       
        private async Task<List<Product>> GetProductsData()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    IsActive=true,
                    ProductId=10
                }
            };
            return products;
        }

        [Test]
        public async Task GetProductsByID()
        {
            int productID = 10;
            productController productController = new productController(_mockproductSVC.Object);
            _mockproductSVC.Setup(x => x.GetProductById(productID)).Returns(GetProductsDataByID());

            var data = productController.GetProduct();
            Assert.NotNull(data);
        }

        private async Task<List<Product>> GetProductsDataByID()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    IsActive=true,
                    ProductId=10
                }
            };
            return products;
        }

        [Test]
        public async Task AddProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    IsActive=true,
                    ProductId=10
                }
            };
            productController productController = new productController(_mockproductSVC.Object);
            _mockproductSVC.Setup(x => x.AddProduct(products)).Returns(AddProductsData());

            var data = productController.GetProduct();
            Assert.NotNull(data);
        }

        private async Task<ProductResponse> AddProductsData()
        {
            ProductResponse productResponse = new ProductResponse();
            productResponse.isCreated = true;

            return productResponse;
        }


        [Test]
        public async Task UpdateProducts()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    IsActive=true,
                    ProductId=10
                }
            };
            productController productController = new productController(_mockproductSVC.Object);
            _mockproductSVC.Setup(x => x.UpdateProduct(products)).Returns(UpdateProductsData());

            var data = productController.GetProduct();
            Assert.NotNull(data);
        }

        private async Task<ProductResponse> UpdateProductsData()
        {

            ProductResponse productResponse = new ProductResponse();
            productResponse.isUpdated = true;

            return productResponse;
        }





    }
}