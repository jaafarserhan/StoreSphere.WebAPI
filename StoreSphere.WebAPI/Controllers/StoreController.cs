using Microsoft.AspNetCore.Mvc;
using StoreSphere.WebAPI.DTOs.StoreDTOs;
using StoreSphere.WebAPI.Interfaces.Services;

namespace StoreSphere.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore(StoreCreationDto storeDto)
        {
            var result = await _storeService.CreateStore(storeDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStore(int id, StoreUpdateDto storeDto)
        {
            var result = await _storeService.UpdateStore(id, storeDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var result = await _storeService.DeleteStore(id);
            return Ok(result);
        }
    }
}