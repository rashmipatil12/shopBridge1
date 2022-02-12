using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopBridge.Model;
using shopBridge.Service.Response;

namespace shopBridge.Service
{
    public interface IProductService
    {
        bool ValidateCredentials(string username, string password);
        Task<List<Product>> GetProduct();

        Task<List<Product>> GetProductById(int productID);

        Task<ProductResponse> AddProduct(List<Product> products);

        Task<ProductResponse> UpdateProduct(List<Product> products);

        Task<ProductResponse> DeleteProductBySoft(List<int> productID);

        Task<ProductResponse> DeleteProductByHard(List<int> productID);
    }
}
