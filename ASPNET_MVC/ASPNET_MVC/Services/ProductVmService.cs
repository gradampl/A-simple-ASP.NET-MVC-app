using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using ASPNET_MVC.Services.Interfaces;
using ASPNET_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_MVC.Services
{
    public class ProductVmService : IProductVmService
    {
        private readonly ASPNET_MVCContext _context;

        public ProductVmService(ASPNET_MVCContext context)
        {
            _context = context;
        }

        public ProductViewModel GetAllProducts(int? categoryId)
        {
            var products = _context.Product.Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId).ToList();

            var model = new ProductViewModel()
            {
                Products = products
            };

            return model;
        }

        public ProductViewModel GetProduct(int? id)
        {
            var model = new ProductViewModel();
            model.Categories = _context.Category.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();

            // check if product exists
            model.EditableProduct = id.HasValue ? _context.Product.Find(id.Value) : new Product();
            
            return model;
        }

        public Product FindOrMakeProduct(ProductViewModel model)
        {
            Product product;

            if (model.EditableProduct.Id > 0)
            {
                product = _context.Product.Find(model.EditableProduct.Id);
            }

            else
            {
                product = new Product();
                _context.Product.Add(product);
            }

            return product;
        }

        public void EditProduct(Product product, ProductViewModel model)
        {
            product.CategoryId = model.EditableProduct.CategoryId;

            product.Name = model.EditableProduct.Name;

            product.Description = model.EditableProduct.Description;

            product.Price = model.EditableProduct.Price;

            _context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _context.Product.Remove(product);

            _context.SaveChanges();
        }
    }
}
