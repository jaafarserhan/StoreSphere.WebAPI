using StoreSphere.WebAPI.DTOs.StoreDTOs;

namespace StoreSphere.WebAPI.Interfaces.Services
{
    public interface IStoreService
    {
        Task<string> CreateStore(StoreCreationDto storeDto);
        Task<string> UpdateStore(int id, StoreUpdateDto storeDto);
        Task<string> DeleteStore(int id);
    }
}
