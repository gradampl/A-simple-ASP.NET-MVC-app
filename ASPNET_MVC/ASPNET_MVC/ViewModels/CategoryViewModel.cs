using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using ASPNET_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNET_MVC.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ProductViewModel> Products { get; set; }

        public CategoryViewModel()
        {
            this.Products=new HashSet<ProductViewModel>();
        }
    }
}
