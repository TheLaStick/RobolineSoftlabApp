using RobolineSoftlabApp.Domain.Models;

namespace RobolineSoftlabApp.Domain.Repositories
{
    public interface IProductsRepository
    {
        List<Product> GetAllProducts();
        Product? GetProductById(int id);
        Task<Product> AddProduct(Product product);
        Task<Product?> UpdateProduct(Product product, int id);
        Task DeleteProduct(int id);
    }
}
