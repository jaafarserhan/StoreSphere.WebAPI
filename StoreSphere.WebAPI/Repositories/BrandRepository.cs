using Microsoft.EntityFrameworkCore;
using StoreSphere.WebAPI.Interfaces.Repositories;
using StoreSphere.WebAPI.Models;

namespace StoreSphere.WebAPI.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly StoreSphereContext _context;

        public BrandRepository(StoreSphereContext context)
        {
            _context = context;
        }

        public async Task<bool> BrandExists(string brandName)
        {
            return await _context.Brands.AnyAsync(b => b.BrandName == brandName);
        }

        public async Task AddBrand(Brand brand)
        {
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
        }

        public async Task<Brand> GetBrandById(int brandId)
        {
            return await _context.Brands.FindAsync(brandId);
        }

        public async Task UpdateBrand(Brand brand)
        {
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBrand(int brandId)
        {
            var brand = await _context.Brands.FindAsync(brandId);
            if (brand != null)
            {
                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();
            }
        }
    }
}
