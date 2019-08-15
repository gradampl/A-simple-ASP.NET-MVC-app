using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using ASPNET_MVC.Repositories;
using ASPNET_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_MVC.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly ASPNET_MVCContext _context;

        public ProductCategoryController(ASPNET_MVCContext context)
        {
            _context = context;
        }

        public IActionResult Index(int categoryId)
        {
            var products = _context.Product.Include(p => p.Category)
                    .Where(p => p.CategoryId == categoryId).ToList();

            var model = new ProductCategoryVM()
            {
                Products = products
            };

            return View(model);
        }
    }
}