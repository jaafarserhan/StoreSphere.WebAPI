using StoreSphere.WebAPI.DTOs.ProductDTOs;
using StoreSphere.WebAPI.Interfaces.Repositories;
using StoreSphere.WebAPI.Interfaces.Services;
using StoreSphere.WebAPI.Models;

namespace StoreSphere.WebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<string> CreateProduct(ProductCreationDto productDto)
        {
            if (!await _productRepository.StoreExists(productDto.StoreID))
                throw new Exception("Invalid StoreID.");

            if (!await _productRepository.BrandExists(productDto.BrandID))
                throw new Exception("Invalid BrandID.");

            var product = new Product
            {
                ProductName = productDto.ProductName,
                StoreID = productDto.StoreID,
                BrandID = productDto.BrandID,
                Price = productDto.Price,
                ImageURL = productDto.ImageURL,
                IsDeleted = false
            };

            await _productRepository.AddProduct(product);
            return "Product created successfully.";
        }

        public async Task<string> UpdateProduct(int id, ProductUpdateDto productDto)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
                throw new Exception("Product not found.");

            product.ProductName = productDto.ProductName;
            product.Price = productDto.Price;
            product.ImageURL = productDto.ImageURL;
            product.IsDeleted = productDto.IsDeleted;

            await _productRepository.UpdateProduct(product);
            return "Product updated successfully.";
        }

        public async Task<string> DeleteProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
                throw new Exception("Product not found.");

            await _productRepository.DeleteProduct(id);
            return "Product deleted successfully.";
        }

        public async Task<string> RecoverProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);
            if (product == null)
                throw new Exception("Product not found.");

            await _productRepository.RecoverProduct(id);
            return "Product recovered successfully.";
        }
    }
}