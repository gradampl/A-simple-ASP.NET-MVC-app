using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using ASPNET_MVC.Services;
using ASPNET_MVC.Services.Interfaces;
using ASPNET_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryVmService _categoryVmService;

        public CategoryController(ICategoryVmService categoryVmService)
        {
            _categoryVmService = categoryVmService;
        }


        public IActionResult Index()
        {
            var result = _categoryVmService.GetAllCategories();

            return View(result);
        }
    }
}

