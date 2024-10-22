using RobolineSoftlabApp.Domain.Models;
using RobolineSoftlabApp.Domain.Repositories;
using RobolineSoftlabApp.Infrastructure.Data;

namespace RobolineSoftlabApp.Infrastructure.Repositories
{
    public class ProductCategoriesRepository : IProductCategoriesRepository
    {
        private RobolineSoftlabAppContext _db;
        public ProductCategoriesRepository(RobolineSoftlabAppContext db)
        {
            _db = db;
        }

        public List<ProductCategory> GetAllCategories()
        {
            return _db.ProductCategories.ToList();
        }

        public ProductCategory? GetCategoryById(int id)
        {
            var query = _db.ProductCategories.Where(x =>  x.Id == id).ToList();
            if (query.Count == 0)
            {
                return null;
            }

            return query[0];
        }

        public async Task<ProductCategory> AddCategory(ProductCategory category)
        {
            var check = _db.ProductCategories.Where(x => x.Name == category.Name &&
                x.Description == category.Description).ToList();
            if (check.Count > 0)
            {
                throw new InvalidDataException("Такая категория уже существует");
            }

            var query = await _db.ProductCategories.AddAsync(category);
            await _db.SaveChangesAsync();
            return query.Entity;
        }

        public async Task<ProductCategory?> UpdateCategory(ProductCategory category, int id)
        {
            var query = _db.ProductCategories.Where(x => x.Id == id).ToList();
            if (query.Count == 0)
            {
                return null;
            }

            var queryCategory = query[0];
            queryCategory.Name = category.Name;
            queryCategory.Description = category.Description;

            await _db.SaveChangesAsync();

            return queryCategory;
        }

        /// <summary>
        /// Gets the category from database by id, deletes all products that has this category, then removes category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteCategory(int id)
        {
            var query = _db.ProductCategories.Where(x => x.Id == id).ToList();
            if (query.Count == 0)
            {
                return;
            }

            var queryCategory = query[0];

            var products = _db.Products.ToList();
            foreach (var product in _db.Products.Where(x => x.CategoryId == queryCategory.Id))  
            {
                _db.Remove(product);
            }

            _db.ProductCategories.Remove(queryCategory);
            await _db.SaveChangesAsync();
        }
    }
}
