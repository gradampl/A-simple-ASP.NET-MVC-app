using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using ASPNET_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_MVC.Services.Interfaces
{
    public interface ICategoryVmService
    {
        CategoryViewModel GetAllCategories();
    }
}
