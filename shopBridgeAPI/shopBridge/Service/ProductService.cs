using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopBridge.Service;
using shopBridge.Infrastructure.Repository;
using shopBridge.Model;

namespace shopBridge.Service
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //Get Product List
        public async Task<List<Product>> GetProduct()
        {
            var productdata = await _productRepository.GetProduct();
            return productdata;
        }

        //Get Product By ID
        public async Task<List<Product>> GetProductById(int productID)
        {
            var productdata =await _productRepository.GetProductById(productID);
           
            return productdata;
        }

        //Add Product
        public async Task<int> AddProduct(List<Product> productVM)
        {
            var productdata = await _productRepository.AddProduct(productVM);

            return productdata;

        }

        //Update Product

        public async Task<int> UpdateProduct(List<Product> productVM)
        {
            var productdata = await _productRepository.UpdateProduct(productVM);

            return productdata;
       }

        //Delete Product-Soft Delete

        public async Task<int> DeleteProductBySoft(List<int> productId)
        {
            var productdata = await _productRepository.DeleteProductBySoft(productId);

            return productdata;
        }

        //Delete Product-Hard Delete

        public async Task<int> DeleteProductByHard(List<int> productID)
        {
            var productdata = await _productRepository.DeleteProductByHard(productID);

            return productdata;
        }

    }
}
