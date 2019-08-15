using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ASPNET_MVC.Models
{
    public partial class ASPNET_MVCContext : DbContext
    {
        public ASPNET_MVCContext (DbContextOptions<ASPNET_MVCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Category> Category { get; set; }
    }
}
