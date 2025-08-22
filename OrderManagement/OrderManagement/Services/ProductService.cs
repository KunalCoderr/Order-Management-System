using OrderManagement.DTOsModels;
using OrderManagement.Models;
using OrderManagement.Repositories.Contracts;
using OrderManagement.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagement.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Product> GetAll() => _repo.GetAll();

        public Product Get(int id) => _repo.GetById(id);

        public void Create(ProductDTO dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };
            _repo.Add(product);
            _repo.Save();
        }

        public void Update(int id, ProductDTO dto)
        {
            var product = new Product
            {
                Id = id,
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };
            _repo.Update(product);
            _repo.Save();
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }
}