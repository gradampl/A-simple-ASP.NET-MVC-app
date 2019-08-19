using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using ASPNET_MVC.Services.Interfaces;
using ASPNET_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_MVC.Services
{
    public class CategoryVmService : ICategoryVmService
    {
        private readonly ASPNET_MVCContext _context;

        public CategoryVmService(ASPNET_MVCContext context)
        {
            _context = context;
        }

        CategoryViewModel ICategoryVmService.GetAllCategories()
        {
            var categories = _context.Category.ToList();

            var model = new CategoryViewModel()
            {
                Categories = categories
            };

            return (model);

        }
    }
}
