using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using ASPNET_MVC.Repositories;
using ASPNET_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_MVC.Services
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> categoryRepository;

        private readonly ASPNET_MVCContext _context;

        public CategoryService(IRepository<Category> categoryRepository, ASPNET_MVCContext context)
        {
            this.categoryRepository = categoryRepository;
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return categoryRepository.GetAll();
        }






        //public IActionResult Index()
        //{

        //    var categories = _context.Category.ToList();

        //    var model = new CategoryViewModel()
        //    {
        //        Categories = categories
        //    };

        //    return View(model);
        //}
    }
}
