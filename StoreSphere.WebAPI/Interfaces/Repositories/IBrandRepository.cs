using StoreSphere.WebAPI.Models;

namespace StoreSphere.WebAPI.Interfaces.Repositories
{
    public interface IBrandRepository
    {
        Task<bool> BrandExists(string brandName);
        Task AddBrand(Brand brand);
        Task<Brand> GetBrandById(int brandId);
        Task UpdateBrand(Brand brand);
        Task DeleteBrand(int brandId);
    }
}
