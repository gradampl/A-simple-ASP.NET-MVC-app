using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_MVC.Models
{
    public partial class Category : BaseModel
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int Id { get; set; }
        
        public Category()
        {
            this.Products=new HashSet<Product>();
        }

        public virtual ICollection<Product> Products { get; set; }
    }
}
