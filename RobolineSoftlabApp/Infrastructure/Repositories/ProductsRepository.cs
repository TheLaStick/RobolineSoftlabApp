﻿using RobolineSoftlabApp.Domain.Models;
using RobolineSoftlabApp.Domain.Repositories;
using RobolineSoftlabApp.Infrastructure.Data;

namespace RobolineSoftlabApp.Infrastructure.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private RobolineSoftlabAppContext _db;

        public ProductsRepository(RobolineSoftlabAppContext db)
        {
            _db = db;
        }

        public List<Product> GetAllProducts() 
        {
            return _db.Products.ToList();
        }

        /// <summary>
        /// Collects all products with corresponding id
        /// </summary>
        /// <param name="id">id of needed product</param>
        /// <returns>The first product that has corresponding id</returns>
        public Product? GetProductById(int id)
        {
            var query = _db.Products.Where(x => x.Id == id)
                .ToList();
            
            if (query.Count == 0)
            {
                return null;
            }

            return query[0];

        }
        /// <summary>
        /// Adds current product to the database
        /// </summary>
        /// <param name="product">Current product that needs to be added</param>
        /// <returns></returns>
        public async Task<Product> AddProduct(Product product)
        {
            var query = await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return query.Entity;
        }
        /// <summary>
        /// Changes all properties (except id) to new ones from current product
        /// </summary>
        /// <param name="product">Current product</param>
        /// <returns>Changed product</returns>
        public async Task<Product?> UpdateProduct(Product product, int id)
        {
            var query = _db.Products.Where(x => x.Id == id).ToList();

            if (query.Count == 0)
            {
                return null;
            }

            var queryProduct = query[0];
            queryProduct.Name = product.Name;
            queryProduct.Description = product.Description;
            queryProduct.Price = product.Price;
            queryProduct.CategoryId = product.CategoryId;

            await _db.SaveChangesAsync();

            return queryProduct;
        }

        /// <summary>
        /// Removes product from database by ID
        /// </summary>
        /// <param name="id">Current ID of product that need to be deleted</param>
        /// <returns></returns>
        public async Task DeleteProduct(int id)
        {
            var query = _db.Products.Where(x => x.Id == id).ToList();
            if (query.Count == 0) {
                return;
            }
            var queryProduct = query[0];

            _db.Products.Remove(queryProduct);
            await _db.SaveChangesAsync();
        }
    }
}