using StoreSphere.WebAPI.DTOs.BrandDTOs;
using StoreSphere.WebAPI.Interfaces.Repositories;
using StoreSphere.WebAPI.Interfaces.Services;
using StoreSphere.WebAPI.Models;

namespace StoreSphere.WebAPI.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<string> CreateBrand(BrandCreationDto brandDto)
        {
            if (await _brandRepository.BrandExists(brandDto.BrandName))
                throw new Exception("Brand name already exists.");

            var brand = new Brand
            {
                BrandName = brandDto.BrandName
            };

            await _brandRepository.AddBrand(brand);
            return "Brand created successfully.";
        }

        public async Task<string> UpdateBrand(int id, BrandUpdateDto brandDto)
        {
            var brand = await _brandRepository.GetBrandById(id);
            if (brand == null)
                throw new Exception("Brand not found.");

            brand.BrandName = brandDto.BrandName;

            await _brandRepository.UpdateBrand(brand);
            return "Brand updated successfully.";
        }

        public async Task<string> DeleteBrand(int id)
        {
            var brand = await _brandRepository.GetBrandById(id);
            if (brand == null)
                throw new Exception("Brand not found.");

            await _brandRepository.DeleteBrand(id);
            return "Brand deleted successfully.";
        }
    }
}