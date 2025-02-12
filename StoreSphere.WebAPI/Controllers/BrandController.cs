using Microsoft.AspNetCore.Mvc;
using StoreSphere.WebAPI.DTOs.BrandDTOs;
using StoreSphere.WebAPI.Interfaces.Services;

namespace StoreSphere.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(BrandCreationDto brandDto)
        {
            var result = await _brandService.CreateBrand(brandDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, BrandUpdateDto brandDto)
        {
            var result = await _brandService.UpdateBrand(id, brandDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var result = await _brandService.DeleteBrand(id);
            return Ok(result);
        }
    }
}