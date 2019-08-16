﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using ASPNET_MVC.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.ExpressionTranslators.Internal;

namespace ASPNET_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ASPNET_MVCContext _context;

        public ProductController(ASPNET_MVCContext context)
        {
            _context = context;
        }



        public IActionResult Index(int categoryId)
        {

            var products = _context.Product.Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId).ToList();

            var model = new ProductViewModel()
            {
                Products = products
            };

            return View(model);
        }


        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            var model = new ProductViewModel();
            model.Categories = _context.Category.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();

            // check if product exists
            model.EditableProduct = id.HasValue ? _context.Product.Find(id.Value) : new Product();

            return View(model);
        }

        // POST: Product/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel model)
        {
            // check validation
            Product product;

            if (model.EditableProduct.Id > 0)
            {
                product = _context.Product.Find(model.EditableProduct.Id);
                int catID = model.EditableProduct.CategoryId;

            }
                
            else
            {
                product = new Product();
                _context.Product.Add(product);
            }

            string price = model.EditableProduct.Price.ToString();

            decimal myDec;

            bool IsNumeric = decimal.TryParse(price, out myDec);


            if (
                ModelState.IsValid &&
                //! String.IsNullOrWhiteSpace(model.EditableProduct.Name) &&
                //! String.IsNullOrWhiteSpace(model.EditableProduct.Description) &&
                (IsNumeric || String.IsNullOrWhiteSpace(price))
               )
            {
                product.CategoryId = model.EditableProduct.CategoryId;

                product.Name = model.EditableProduct.Name;

                product.Description = model.EditableProduct.Description;

                product.Price = model.EditableProduct.Price;

                _context.SaveChanges();

                return RedirectToAction("Index", new { categoryid = model.EditableProduct.CategoryId });
            }

            return RedirectToAction("Edit", "Product");
        }


        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            var model = new ProductViewModel();
            model.Categories = _context.Category.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();

            // check if product exists
            model.EditableProduct = id.HasValue ? _context.Product.Find(id.Value) : new Product();

            return View(model);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(ProductViewModel model)
        {
            Product product;

            if (model.EditableProduct.Id > 0)
                {
                    product = _context.Product.Find(model.EditableProduct.Id);

                    int _categoryId = product.CategoryId;

                    _context.Product.Remove(product);

                    _context.SaveChanges();

                    return RedirectToAction("Index", new { categoryid = _categoryId});
                }

                return View(model);
        }
    }
}