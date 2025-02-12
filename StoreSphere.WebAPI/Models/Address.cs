namespace StoreSphere.WebAPI.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool IsActive { get; set; }

        // Foreign Key to Store
        public int StoreID { get; set; }
        public Store Store { get; set; }
    }
}