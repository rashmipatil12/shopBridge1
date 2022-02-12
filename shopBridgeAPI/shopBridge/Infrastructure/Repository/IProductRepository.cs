using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopBridge.Model;

namespace shopBridge.Infrastructure.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProduct();

        Task<List<Product>> GetProductById(int productID);

        Task<int> AddProduct(List<Product> products);

        Task<int> UpdateProduct(List<Product> products);

        Task<int> DeleteProductBySoft(List<int> productID);

        Task<int> DeleteProductByHard(List<int> productID);
    }
}
