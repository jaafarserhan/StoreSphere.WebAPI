using StoreSphere.WebAPI.DTOs.ProductDTOs;

namespace StoreSphere.WebAPI.Interfaces.Services
{
    public interface IProductService
    {
        Task<string> CreateProduct(ProductCreationDto productDto);
        Task<string> UpdateProduct(int id, ProductUpdateDto productDto);
        Task<string> DeleteProduct(int id);
        Task<string> RecoverProduct(int id);
    }
}