using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_MVC.Models
{
    public class Category : BaseModel
    {
        public ICollection<Product> Products { get; set; }
    }
}
