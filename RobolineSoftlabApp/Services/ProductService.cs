using RobolineSoftlabApp.Domain.Models;
using RobolineSoftlabApp.Domain.Repositories;

namespace RobolineSoftlabApp.Services
{
    public class ProductService
    {
        private IProductsRepository _productsRepo;
        public ProductService(IProductsRepository productsRepository)
        {
            this._productsRepo = productsRepository;
        }

        public List<Product> GetAllProducts()
        {
            return _productsRepo.GetAllProducts();
        }

        public Product? GetProductById(int id)
        {
            return _productsRepo.GetProductById(id);
        }

        /// <summary>
        /// Clears name and description in product, checks if they aren't empty and if price is non-negative.
        /// If so, proceeds to adding the product to the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<Product> AddProduct(Product product)
        {
            product.Name = product.Name.Trim();
            product.Description = product.Description.Trim();

            if (product.Name.Length == 0)
            {
                throw new InvalidDataException("Товар не может быть без названия");
            }
            if (product.Description.Length == 0)
            {
                throw new InvalidDataException("Товар не может быть без описания");
            }
            if (product.Price < 0)
            {
                throw new InvalidDataException("Товар не может иметь отрицательную цену");
            }

            return await _productsRepo.AddProduct(product);
        }
        /// <summary>
        /// Clears name and description in product, checks if they aren't empty and if price is non-negative.
        /// If so, proceeds to updating the product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<Product?> UpdateProduct(Product product, int id)
        {
            product.Name = product.Name.Trim();
            product.Description = product.Description.Trim();
            if (product.Name.Length == 0)
            {
                throw new InvalidDataException("Товар не может быть без названия");
            }
            if (product.Description.Length == 0)
            {
                throw new InvalidDataException("Товар не может быть без описания");
            }
            if (product.Price < 0)
            {
                throw new InvalidDataException("Товар не может иметь отрицательную цену");
            }
            

            return await _productsRepo.UpdateProduct(product, id);
        }

        public async Task DeleteProduct(int id)
        {
            await _productsRepo.DeleteProduct(id);
        }
    }
}
