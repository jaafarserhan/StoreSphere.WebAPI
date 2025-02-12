namespace StoreSphere.WebAPI.DTOs.ProductDTOs
{
    public class ProductUpdateDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public bool IsDeleted { get; set; }
    }
}