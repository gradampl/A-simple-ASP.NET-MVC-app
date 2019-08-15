using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using ASPNET_MVC.Services;
using ASPNET_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_MVC.Controllers
{
    public class CategoryController : Controller
    {
        protected ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            List<CategoryViewModel> model = new List<CategoryViewModel>();

            categoryService.GetCategories().ToList().ForEach(c =>
            {
                CategoryViewModel category = new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                };
                model.Add(category);
            });

            return View(model);
        }

        //private readonly ASPNET_MVCContext _context;

        //public CategoryController(ASPNET_MVCContext context)
        //{
        //    _context = context;
        //}

        //public IActionResult Index()
        //{

        //    var categories = _context.Category.ToList();

        //    var model = new CategoryViewModel()
        //    {
        //        Categories = categories
        //    };

        //    return View(model);
    }
}
