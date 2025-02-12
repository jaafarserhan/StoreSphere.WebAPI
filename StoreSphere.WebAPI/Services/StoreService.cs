using StoreSphere.WebAPI.DTOs.StoreDTOs;
using StoreSphere.WebAPI.Interfaces.Repositories;
using StoreSphere.WebAPI.Interfaces.Services;
using StoreSphere.WebAPI.Models;

namespace StoreSphere.WebAPI.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<string> CreateStore(StoreCreationDto storeDto)
        {
            if (await _storeRepository.StoreExists(storeDto.StoreName))
                throw new Exception("Store name already exists.");

            var store = new Store
            {
                StoreName = storeDto.StoreName,
                UserID = storeDto.UserID,
                BrandID = storeDto.BrandID,
                LogoURL = storeDto.LogoURL,
                IsActive = true
            };

            await _storeRepository.AddStore(store);
            return "Store created successfully.";
        }

        public async Task<string> UpdateStore(int id, StoreUpdateDto storeDto)
        {
            var store = await _storeRepository.GetStoreById(id);
            if (store == null)
                throw new Exception("Store not found.");

            store.StoreName = storeDto.StoreName;
            store.LogoURL = storeDto.LogoURL;
            store.IsActive = storeDto.IsActive;

            await _storeRepository.UpdateStore(store);
            return "Store updated successfully.";
        }

        public async Task<string> DeleteStore(int id)
        {
            var store = await _storeRepository.GetStoreById(id);
            if (store == null)
                throw new Exception("Store not found.");

            await _storeRepository.DeleteStore(id);
            return "Store deleted successfully.";
        }
    }
}