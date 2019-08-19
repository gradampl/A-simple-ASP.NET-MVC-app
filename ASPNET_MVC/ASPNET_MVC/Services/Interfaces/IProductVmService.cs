using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using ASPNET_MVC.ViewModels;

namespace ASPNET_MVC.Services.Interfaces
{
    public interface IProductVmService
    {
       ProductViewModel GetAllProducts(int? categoryId);

       ProductViewModel GetProduct(int? id);

       Product FindOrMakeProduct(ProductViewModel model);

       void EditProduct(Product product, ProductViewModel model);

       void DeleteProduct(Product product);
    }
}
