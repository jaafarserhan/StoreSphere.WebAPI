using StoreSphere.WebAPI.Models;

namespace StoreSphere.WebAPI.Interfaces.Repositories
{
    public interface IStoreRepository
    {
        Task<bool> StoreExists(string storeName);
        Task AddStore(Store store);
        Task<Store> GetStoreById(int storeId);
        Task UpdateStore(Store store);
        Task DeleteStore(int storeId);
    }
}
