namespace StoreSphere.WebAPI.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public bool IsDeleted { get; set; }

        // Foreign Key to Store
        public int StoreID { get; set; }
        public Store Store { get; set; }

        // Foreign Key to Brand
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
    }
}