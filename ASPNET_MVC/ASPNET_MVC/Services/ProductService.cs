using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_MVC.Services
{
    public class ProductService
    {
        private readonly ASPNET_MVCContext _context;

        public ProductService(ASPNET_MVCContext context)
        {
            _context = context;
        }


    }
}
