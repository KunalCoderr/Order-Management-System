using OrderManagement.Models;
using OrderManagement.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products = new List<Product>();
        private static int _nextId = 1;

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
                _products.Remove(product);
        }
    }
}