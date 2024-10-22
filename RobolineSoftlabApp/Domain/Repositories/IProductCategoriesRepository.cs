using RobolineSoftlabApp.Domain.Models;

namespace RobolineSoftlabApp.Domain.Repositories
{
    public interface IProductCategoriesRepository
    {
        List<ProductCategory> GetAllCategories();
        ProductCategory? GetCategoryById(int id);
        Task<ProductCategory> AddCategory(ProductCategory category);
        Task<ProductCategory?> UpdateCategory(ProductCategory category, int id);
        Task DeleteCategory(int id);
    }
}
