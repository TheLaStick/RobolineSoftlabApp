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
    public class ProductCategoriesController : Controller
    {
        private ProductCategoryService _categoryService;

        public ProductCategoriesController(ProductCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("categories/all")]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetAllCategories()
        {
            return _categoryService.GetAllCategories();
        }

        [HttpGet("categories/{id}")]
        public async Task<ActionResult<ProductCategory>> GetCategoryById(int? id)
        {
            if (!id.HasValue)
            {
                return new NotFoundResult();
            }

            var category = _categoryService.GetCategoryById(id.Value);
            if (category == null)
            {
                return new NotFoundResult();
            }
            return category;
        }


        [HttpPost("categories/all")]
        public async Task<ActionResult<ProductCategory>> AddNewCategory(ProductCategory productCategory)
        {
            try
            {
                return await _categoryService.AddCategory(productCategory);
            }
            catch (ArgumentException ex)
            {
                return new ContentResult()
                {
                    Content = ex.Message,
                    StatusCode = 400
                };
            }
        }

        [HttpPut("categories/all")]
        public async Task<ActionResult<ProductCategory>> UpdateProduct(ProductCategory category, int? id)
        {
            if (!id.HasValue)
            {
                return new NotFoundResult();
            }

            var result = await _categoryService.UpdateCategory(category, id.Value);
            
            if (result == null)
            {
                return new NotFoundResult();
            }
            return result;
        }

        [HttpDelete("categories/{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new NotFoundResult();
            }

            await _categoryService.DeleteCategory(id.Value);
            return new OkResult();
        }

    }
}
