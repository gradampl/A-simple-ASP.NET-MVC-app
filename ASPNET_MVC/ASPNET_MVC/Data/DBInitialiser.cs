using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_MVC.Models;

namespace ASPNET_MVC.Models
{
    public static class DBInitialiser
    {
        public static void Initialise(ASPNET_MVCContext context)
        {
            // Look for any products.
            //if (context.Product.Any())
            //{
            //    return;   // DB has been seeded
            //}

            var products1 = new Product[]
            {
                new Product {Description = "wygodny, jasnobrazowy", Name = "taboret kuchenny"},
                new Product {Description = "podwieszany, plazmowy", Name = "telewizor"},
                new Product {Description = "kompaktowa, ladowana od gory", Name = "pralka"}
            };

            foreach (var p in products1)
            {
                context.Product.Add(p);
            }

            context.SaveChanges();

            var products2 = new Product[]
            {
                new Product {Description = "pszenny, jasny", Name = "chleb"},
                new Product {Description = "irlandzkie, niesolone", Name = "maslo"},
                new Product {Description = "niepasteryzowane, swieze", Name = "mleko"}
            };

            foreach (var d in products2)
            {
                context.Product.Add(d);
            }

            context.SaveChanges();

            var categories = new Category[]
            {
                new Category {Name = "Art. Spozywcze", Products = products2},
                new Category {Name = "AGD", Products = products1}
            };

            foreach (var c in categories)
            {
                context.Category.Add(c);
            }

            context.SaveChanges();
        }
    }
}
