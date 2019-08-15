using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using ASPNET_MVC.ViewModels;

namespace ASPNET_MVC.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
    }
}
