namespace ASPNET_MVC.Models
{
    public class Product : BaseModel
    {
        public string Description { get; set; }

        public decimal? Price { get; set; }

        public Category Category { get; set; }
    }
}