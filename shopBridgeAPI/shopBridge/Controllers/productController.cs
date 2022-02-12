using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopBridge.Model;
using shopBridge.Service;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace shopBridge.Controllers
{
 //   [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class productController : ControllerBase
    {


        private readonly IProductService _productService;
       // private readonly IConfiguration _configuration;

        public productController(IProductService productService)
        {
            _productService = productService;
           // _configuration = configuration;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProduct()
        {
            ObjectResult result = null;
            try
            {
                var productdata = await _productService.GetProduct();

                if (productdata != null)
                {
                    
                    result = new OkObjectResult(productdata);
                   
                }
            }catch(Exception ex)
            {
                throw;
            }
            return  result;
        }

        [HttpGet("GetProductByID")]

        public async Task<IActionResult> GetProduct(int productID)
        {
            ObjectResult result = null;
            try
            {
                var productdata = await _productService.GetProductById(productID);

                if (productdata != null)
                {
                    result = new OkObjectResult(productdata);

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(List<Product> productVM)
        {
            ObjectResult result = null;
            try
            {
                var productdata = await _productService.AddProduct(productVM);

                if (productdata != null)
                {
                    result = new OkObjectResult(productdata);

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }


        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(List<Product> productVM)
        {
            ObjectResult result = null;
            try
            {
                var productdata = await _productService.UpdateProduct(productVM);

                if (productdata != null)
                {
                    result = new OkObjectResult(productdata);

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;

        }


        [HttpDelete("DeleteProductSoft")]
        public async Task<IActionResult> DeleteProductSoft(List<int> productID)
        {
            ObjectResult result = null;
            try
            {
                var productdata = await _productService.DeleteProductBySoft(productID);

                if (productdata != null)
                {
                    result = new OkObjectResult(productdata);

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;

        }


        [HttpDelete("DeleteProductHard")]
        public async Task<IActionResult> DeleteProductHard(List<int> productID)
        {
            ObjectResult result = null;
            try
            {
                var productdata = await _productService.DeleteProductByHard(productID);

                if (productdata != null)
                {
                    result = new OkObjectResult(productdata);

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;

        }
    }
}
