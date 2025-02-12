using Microsoft.EntityFrameworkCore;
using StoreSphere.WebAPI.Interfaces.Repositories;
using StoreSphere.WebAPI.Models;

namespace StoreSphere.WebAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreSphereContext _context;

        public ProductRepository(StoreSphereContext context)
        {
            _context = context;
        }

        public async Task<bool> StoreExists(int storeId)
        {
            return await _context.Stores.AnyAsync(s => s.StoreID == storeId);
        }

        public async Task<bool> BrandExists(int brandId)
        {
            return await _context.Brands.AnyAsync(b => b.BrandID == brandId);
        }

        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _context.Products.FindAsync(productId);
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                product.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task RecoverProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                product.IsDeleted = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
