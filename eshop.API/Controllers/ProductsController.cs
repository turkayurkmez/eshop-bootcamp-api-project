using eshop.Models;
using eshop.Models.DataTransferObjects.Responses;
using eshop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public async  Task<IActionResult> GetProducts()
        {            
            var products = await productService.GetProducts();
            return Ok(products);
        }
    }
}
