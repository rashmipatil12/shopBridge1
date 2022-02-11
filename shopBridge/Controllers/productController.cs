using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopBridge.Model;

namespace shopBridge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class productController : ControllerBase
    {


        private readonly shopBridgeContext _context;

        public productController(shopBridgeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Product> GetProduct()
        {
            return  _context.Product.ToList();
        }

        [HttpGet("GetProductByID")]

        public IEnumerable<Product> GetProduct(int productID)
        {
            return _context.Product.Where(c=>c.ProductId==productID).ToList();
        }

        [HttpPost("AddProduct")]
        public int AddProduct(Product productVM)
        {
           _context.Product.Add(productVM);
           var isadded = _context.SaveChanges();
            
            return isadded;
        }


        [HttpPost("UpdateProduct")]
        public int  UpdateProduct(Product productVM)
        {
            Product product = _context.Product.Where(c => c.ProductId == productVM.ProductId).FirstOrDefault();
             product.ProductPrice = productVM.ProductPrice;
            _context.Product.Update(product);
            var isupdated = _context.SaveChanges();

            return isupdated;
            
        }
    }
}
