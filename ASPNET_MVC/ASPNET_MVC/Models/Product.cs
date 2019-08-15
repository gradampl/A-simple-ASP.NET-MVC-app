using System;
using System.ComponentModel.DataAnnotations;

namespace ASPNET_MVC.Models
{
    public partial class Product : BaseModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}