using StoreSphere.WebAPI.DTOs.BrandDTOs;

namespace StoreSphere.WebAPI.Interfaces.Services
{
    public interface IBrandService
    {
        Task<string> CreateBrand(BrandCreationDto brandDto);
        Task<string> UpdateBrand(int id, BrandUpdateDto brandDto);
        Task<string> DeleteBrand(int id);
    }
}