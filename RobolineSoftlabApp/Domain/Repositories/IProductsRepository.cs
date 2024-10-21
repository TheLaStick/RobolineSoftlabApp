using RobolineSoftlabApp.Domain.Models;

namespace RobolineSoftlabApp.Domain.Repositories
{
    public interface IProductsRepository
    {
        Product GetProductById(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
