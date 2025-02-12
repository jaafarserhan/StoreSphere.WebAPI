using Microsoft.EntityFrameworkCore;
using StoreSphere.WebAPI.Interfaces.Repositories;
using StoreSphere.WebAPI.Models;

namespace StoreSphere.WebAPI.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreSphereContext _context;

        public StoreRepository(StoreSphereContext context)
        {
            _context = context;
        }

        public async Task<bool> StoreExists(string storeName)
        {
            return await _context.Stores.AnyAsync(s => s.StoreName == storeName);
        }

        public async Task AddStore(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
        }

        public async Task<Store> GetStoreById(int storeId)
        {
            return await _context.Stores.FindAsync(storeId);
        }

        public async Task UpdateStore(Store store)
        {
            _context.Stores.Update(store);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStore(int storeId)
        {
            var store = await _context.Stores.FindAsync(storeId);
            if (store != null)
            {
                _context.Stores.Remove(store);
                await _context.SaveChangesAsync();
            }
        }
    }
}
