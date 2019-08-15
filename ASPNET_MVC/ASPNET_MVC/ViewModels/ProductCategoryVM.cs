using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNET_MVC.ViewModels
{
    public class ProductCategoryVM
    {
        //public ProductCategoryVM()
        //{
            
        //}
        public List<SelectListItem> Categories { get; set; }
        //public Product EditableProduct { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
