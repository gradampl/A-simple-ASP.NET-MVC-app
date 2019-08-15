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
            if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }


            var categories = new Category[]
            {

                new Category {Name = "Art. Spozywcze", Products = new Product[]
                    {
                        new Product {Description = "pszenny, jasny", Name = "chleb",CategoryId = 1},
                        new Product {Description = "irlandzkie, niesolone", Name = "maslo",CategoryId = 1},
                        new Product {Description = "niepasteryzowane, swieze", Name = "mleko",CategoryId = 1}
                    },

                    Id = 1
                },



                new Category {Name = "AGD", Products = new Product[]
                    {
                        new Product {Description = "wygodny, jasnobrazowy", Name = "taboret kuchenny",CategoryId = 2},
                        new Product {Description = "podwieszany, plazmowy", Name = "telewizor",CategoryId = 2},
                        new Product {Description = "kompaktowa, ladowana od gory", Name = "pralka",CategoryId = 2}
                    },

                    Id = 2
                }

            };

            foreach (var c in categories)
            {
                context.Category.Add(c);
            }

            context.SaveChanges();

        }
    }
}
