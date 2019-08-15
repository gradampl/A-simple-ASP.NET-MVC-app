using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using ASPNET_MVC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_MVC.Services
{
    public class ProductService:IProductService
    {
        private IRepository<Product> productRepository;
        
        public ProductService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts()
        {
            return productRepository.GetAll();
        }

        public Product GetProduct(int id)
        {
            return productRepository.Get(id);
        }

        public void InsertProduct(Product product)
        {
            productRepository.Insert(product);
        }

        public void UpdateProduct (Product product)
        {
            productRepository.Update(product);
        }

        public void DeleteProduct(Product product)
        {
            productRepository.Delete(product);
        }
    }
}
