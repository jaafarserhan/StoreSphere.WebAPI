using Microsoft.AspNetCore.Mvc;
using StoreSphere.WebAPI.DTOs.ProductDTOs;
using StoreSphere.WebAPI.Interfaces.Services;

namespace StoreSphere.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreationDto productDto)
        {
            var result = await _productService.CreateProduct(productDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDto productDto)
        {
            var result = await _productService.UpdateProduct(id, productDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            return Ok(result);
        }

        [HttpPost("{id}/recover")]
        public async Task<IActionResult> RecoverProduct(int id)
        {
            var result = await _productService.RecoverProduct(id);
            return Ok(result);
        }
    }
}