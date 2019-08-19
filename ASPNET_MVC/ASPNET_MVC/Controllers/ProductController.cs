using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using ASPNET_MVC.Services.Interfaces;
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
        private readonly IProductVmService _productVmService;

        public ProductController(IProductVmService productVmService)
        {
            _productVmService = productVmService;
        }



        public IActionResult Index(int categoryId)
        {
            return View(_productVmService.GetAllProducts(categoryId));
        }



        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            return View(_productVmService.GetProduct(id));
        }

        // POST: Product/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel model)
        {
            var product = _productVmService.FindOrMakeProduct(model);

            string price = model.EditableProduct.Price.ToString();
            decimal myDec;
            bool IsNumeric = decimal.TryParse(price, out myDec);
            
                         //Validation
            if (ModelState.IsValid &&
             (IsNumeric || String.IsNullOrWhiteSpace(price))
            )

            {
                _productVmService.EditProduct(product, model);

                return RedirectToAction("Index", new {categoryid = model.EditableProduct.CategoryId});
            }

            return RedirectToAction("Edit", "Product");
        }



        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            return View(_productVmService.GetProduct(id));
        }


        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(ProductViewModel model)
        {
            var product = _productVmService.FindOrMakeProduct(model);

            int _categoryId = product.CategoryId;

            _productVmService.DeleteProduct(product);

            return RedirectToAction("Index", new {categoryid = _categoryId});


        }
    }
}