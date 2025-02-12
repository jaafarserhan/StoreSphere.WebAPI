namespace StoreSphere.WebAPI.Models
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }

        // Navigation properties
        public ICollection<Store> Stores { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}