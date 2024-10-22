using RobolineSoftlabApp.Domain.Models;
using RobolineSoftlabApp.Domain.Repositories;

namespace RobolineSoftlabApp.Services
{
    public class ProductCategoryService
    {
        private IProductCategoriesRepository _categoriesRepo;

        public ProductCategoryService(IProductCategoriesRepository categoriesRepo)
        {
            _categoriesRepo = categoriesRepo;
        }

        public List<ProductCategory> GetAllCategories()
        {
            return _categoriesRepo.GetAllCategories();
        }

        public ProductCategory? GetCategoryById(int id)
        {
            return _categoriesRepo.GetCategoryById(id);
        }

        /// <summary>
        /// Clears name and description in product, checks if they aren't empty.
        /// If so, proceeds to adding the category to the database
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<ProductCategory> AddCategory(ProductCategory category)
        {
            category.Name = category.Name.Trim();
            category.Description = category.Description.Trim();

            if (category.Name.Length == 0)
            {
                throw new ArgumentException("Категория не может быть без названия");
            }
            if (category.Description.Length == 0) 
            {
                throw new ArgumentException("Категория не может быть без описания");
            }
            
            return await _categoriesRepo.AddCategory(category);
        }

        /// <summary>
        /// Clears name and description in product, checks if they aren't empty and if price is non-negative.
        /// If so, proceeds to updating the category
        /// </summary>
        /// <param name="category"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<ProductCategory?> UpdateCategory(ProductCategory category, int id)
        {
            category.Name = category.Name.Trim();
            category.Description = category.Description.Trim();

            if (category.Name.Length == 0)
            {
                throw new ArgumentException("Категория не может быть без названия");
            }
            if (category.Description.Length == 0)
            {
                throw new ArgumentException("Категория не может быть без описания");
            }

            return await _categoriesRepo.UpdateCategory(category, id);
        }

        public async Task DeleteCategory(int id)
        {
            await _categoriesRepo.DeleteCategory(id);
        }
    }
}
