using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ASPNET_MVC.Models
{
    public partial class Product : BaseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string Description { get; set; }
        
        public decimal? Price { get; set; }

        public virtual Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}