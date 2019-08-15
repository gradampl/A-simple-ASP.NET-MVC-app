using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNET_MVC.ViewModels
{
    public class ProductViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
}
