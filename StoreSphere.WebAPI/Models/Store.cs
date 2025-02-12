namespace StoreSphere.WebAPI.Models
{
    public class Store
    {
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string LogoURL { get; set; }
        public bool IsActive { get; set; }

        // Foreign Key to User
        public int UserID { get; set; }
        public User User { get; set; }

        // Foreign Key to Brand
        public int BrandID { get; set; }
        public Brand Brand { get; set; }

        // Navigation properties
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}