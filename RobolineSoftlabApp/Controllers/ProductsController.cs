using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RobolineSoftlabApp.Domain.Models;
using RobolineSoftlabApp.Infrastructure.Data;
using RobolineSoftlabApp.Services;

namespace RobolineSoftlabApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products/all")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }

        [HttpGet("products/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int? id)
        {
            if (!id.HasValue)
            {
                return new NotFoundResult();
            }

            var product = _productService.GetProductById(id.Value);
            if (product == null)
            {
                return new NotFoundResult();
            }

            return product;
        }

        [HttpPost("products/all")]
        public async Task<ActionResult<Product>> AddNewProduct(Product product)
        {
            try
            {
                return await _productService.AddProduct(product);
            }
            catch (InvalidDataException ex)
            {
                return new ContentResult()
                {
                    Content = ex.Message,
                    StatusCode = 400
                };
            }
        }

        [HttpPut("products/{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(Product product, int? id)
        {
            if (!id.HasValue)
            {
                return new NotFoundResult();
            }

            var result = await _productService.UpdateProduct(product, id.Value);

            if (result == null)
            {
                return new NotFoundResult();
            }
            return result;
        }

        [HttpDelete("products/{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new NotFoundResult();
            }

            await _productService.DeleteProduct(id.Value);

            return new OkResult();
        }
    }
}
