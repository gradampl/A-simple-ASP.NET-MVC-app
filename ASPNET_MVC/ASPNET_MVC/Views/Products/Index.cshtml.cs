using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPNET_MVC.Models;

namespace ASPNET_MVC.Views.Products
{
    public class IndexModel : PageModel
    {
        private readonly ASPNET_MVC.Models.ASPNET_MVCContext _context;

        public IndexModel(ASPNET_MVC.Models.ASPNET_MVCContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}
