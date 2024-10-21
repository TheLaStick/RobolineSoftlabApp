using RobolineSoftlabApp.Domain.Models;

namespace RobolineSoftlabApp.Domain.Repositories
{
    public interface IProductCategoriesRepository
    {
        ProductCategory GetProductCategory(int id);
        Task<ProductCategory> AddProductCategory(ProductCategory category);
        Task<ProductCategory> UpdateProductCategory(ProductCategory category);
        Task<ProductCategory> DeleteProductCategory(int id);
    }
}
