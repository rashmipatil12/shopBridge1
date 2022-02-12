using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopBridge.Service;
using shopBridge.Infrastructure.Repository;
using shopBridge.Model;
using shopBridge.Service.Response;

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
        public async Task<ProductResponse> AddProduct(List<Product> productVM)
        {
            ProductResponse productResponse = new ProductResponse();

            var productdata = await _productRepository.AddProduct(productVM);

            if(productdata>0)
            {
                productResponse.isCreated = true;
                productResponse.isDeleted = false;
                productResponse.isUpdated = false;
            }
            else
            {
                productResponse.isCreated = false;
                productResponse.isDeleted = false;
                productResponse.isUpdated = false;
            }
            return productResponse;

        }

        //Update Product
        
        public async Task<ProductResponse> UpdateProduct(List<Product> productVM)
        {
            ProductResponse productResponse = new ProductResponse();

            var productdata = await _productRepository.UpdateProduct(productVM);
            if (productdata > 0)
            {
                productResponse.isUpdated = true;
                productResponse.isDeleted = false;
                productResponse.isCreated = false;
            }
            else
            {
                productResponse.isCreated = false;
                productResponse.isDeleted = false;
                productResponse.isUpdated = false;
            }
            return productResponse;
       }

        //Delete Product-Soft Delete

        public async Task<ProductResponse> DeleteProductBySoft(List<int> productId)
        {
            ProductResponse productResponse = new ProductResponse();
            var productdata = await _productRepository.DeleteProductBySoft(productId);
            if (productdata > 0)
            {
                productResponse.isUpdated = false;
                productResponse.isDeleted = true;
                productResponse.isCreated = false;
            }
            else
            {
                productResponse.isCreated = false;
                productResponse.isDeleted = false;
                productResponse.isUpdated = false;
            }
            return productResponse;
        }

        //Delete Product-Hard Delete

        public async Task<ProductResponse> DeleteProductByHard(List<int> productID)
        {
            ProductResponse productResponse = new ProductResponse();
            var productdata = await _productRepository.DeleteProductByHard(productID);
            if (productdata > 0)
            {
                productResponse.isUpdated = false;
                productResponse.isDeleted = true;
                productResponse.isCreated = false;
            }
            else
            {
                productResponse.isCreated = false;
                productResponse.isDeleted = false;
                productResponse.isUpdated = false;
            }
            return productResponse;
        }

    }
}
