namespace StoreSphere.WebAPI.DTOs.ProductDTOs
{
    public class ProductCreationDto
    {
        public string ProductName { get; set; }
        public int StoreID { get; set; }
        public int BrandID { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
    }
}