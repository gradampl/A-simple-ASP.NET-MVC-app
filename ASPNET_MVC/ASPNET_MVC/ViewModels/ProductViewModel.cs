﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNET_MVC.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            EditableProduct = new Product
            {
                Id = EditableProduct.Id,
                Name = EditableProduct.Name,
                Description = EditableProduct.Description,
                Price = EditableProduct.Price,
                CategoryId = EditableProduct.CategoryId
            };
        }

        public List<SelectListItem> Categories { get; set; }
        public Product EditableProduct { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
