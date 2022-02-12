using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shopBridge.Infrastructure.Repository;
using shopBridge.Model;

namespace shopBridge.Infrastructure.Repository
{
    public class ProductRepository:IProductRepository
    {

        private readonly shopBridgeContext _context;

        public ProductRepository(shopBridgeContext context)
        {
            _context = context;
        }

        //Get Product List
        public async Task<List<Product>> GetProduct()
        {

            return await _context.Product.ToListAsync();
        }

        //Get Product By ID
        public async Task<List<Product>> GetProductById(int productID)
        {
            return await _context.Product.Where(c => c.ProductId == productID).ToListAsync();
        }

        //Add Product
        public async Task<int> AddProduct(List<Product> productVM)
        {
            foreach(var productdata in productVM)
            {
                _context.Product.Add(productdata);
            }
          
            var isProductAdded =  _context.SaveChanges();

            return  isProductAdded;
        }

        //Update Product

        public async Task<int> UpdateProduct(List<Product> productVM)
        {
            foreach (var productdata in productVM)
            {
                Product product = _context.Product.Where(c => c.ProductId == productdata.ProductId).FirstOrDefault();
                product.ProductPrice = productdata.ProductPrice;
                _context.Product.Update(product);
            }
            
            var isProductUpdated = _context.SaveChanges();

            return isProductUpdated;

        }


        //Delete Product -Soft delete

        public async Task<int> DeleteProductBySoft(List<int> productID)
        {
            foreach (var productdata in productID)
            {
                Product product = _context.Product.Where(c => c.ProductId == productdata).FirstOrDefault();
                product.IsActive = false;
                _context.Product.Update(product);
            }

            var isProductUpdated = _context.SaveChanges();

            return isProductUpdated;

        }


        //Delete Product -Hard delete

        public async Task<int> DeleteProductByHard(List<int> productID)
        {
            foreach (var productdata in productID)
            {
                Product product = _context.Product.Where(c => c.ProductId == productdata).FirstOrDefault();
               
                _context.Product.Remove(product);
            }

            var isProductUpdated = _context.SaveChanges();

            return isProductUpdated;

        }
    }
}
