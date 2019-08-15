using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using ASPNET_MVC.Services;
using ASPNET_MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ASPNET_MVC.Controllers
{
    public class ProductController : Controller
    {
        protected IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }



        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ProductViewModel model = new ProductViewModel();
            if (id.HasValue && id != 0)
            {
                productService.GetProduct(id.Value);
            }
            else
            {
                model = new ProductViewModel();
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            if (model.Id > 0)
            {
                Product product = productService.GetProduct(model.Id);

                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.Category = model.Category;
                product.CategoryId = model.CategoryId;

                productService.UpdateProduct(product);
                if (product.Id > 0)
                {
                    return RedirectToAction("Index", "ProductCategory", new {categoryId = model.CategoryId});
                }

                return View(model);
            }
            else
            {
                Product product = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    Category = model.Category,
                    CategoryId = model.CategoryId
                };

                productService.InsertProduct(product);
                if (product.Id > 0)
                {
                    return RedirectToAction("Index", "ProductCategory", new {categoryId = model.CategoryId});
                }

                return View(model);
            }
        }





        [HttpGet]
        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            ProductViewModel model = new ProductViewModel();
            if (id.HasValue && id != 0)
            {
                productService.GetProduct(id.Value);
            }

            return PartialView(model);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(ProductViewModel model)
        {
            Product product = productService.GetProduct(model.Id);

            int _categoryId = model.CategoryId;

            if (product.Id > 0)
            {
                return View(model);
            }



            productService.DeleteProduct(product);

            return RedirectToAction("Index", "ProductCategory", new {categoryId = model.CategoryId});

        }
    }
}