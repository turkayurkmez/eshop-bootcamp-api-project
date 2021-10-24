using eshop.API.Filters;
using eshop.Models;
using eshop.Models.DataTransferObjects.Requests;
using eshop.Models.DataTransferObjects.Responses;
using eshop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
    //[Authorize]
    //[EnableCors("Allow")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]

        public async Task<IActionResult> GetProducts()
        {
            var products = await productService.GetProducts();
            return Ok(products);
        }
        [HttpGet("{id}")]
        // [Authorize(Roles = "Admin,Editor")]
        public async Task<IActionResult> GetProductId(int id)
        {
            ProductDetailedResponse product = await productService.GetProduct(id);
            return Ok(product);
        }

        [HttpGet("Search/{name}")]
        public async Task<IActionResult> SearchProduct(string name)
        {
            var result = await productService.GetProductsByName(name);
            return Ok(result);
        }

        [HttpPost]
        //[Authorize(Roles = "Admin,Editor")]
        public async Task<IActionResult> AddProduct(AddProductRequest addProductRequest)
        {
            if (ModelState.IsValid)
            {
                int lastProductId = await productService.AddNewProduct(addProductRequest);
                return CreatedAtAction(nameof(GetProductId), new { id = lastProductId }, null);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        [ItemExists]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductRequest request)
        {
            if (ModelState.IsValid)
            {
                var product = await productService.UpdateProduct(request);
                return Ok(product);
            }
            return BadRequest(ModelState);

        }
        [HttpDelete("{id}")]
        [ItemExists]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await productService.DeleteProduct(id);
            return Ok(product);
        }


    }
}
