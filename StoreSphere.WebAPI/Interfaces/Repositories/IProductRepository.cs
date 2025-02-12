using StoreSphere.WebAPI.Models;

namespace StoreSphere.WebAPI.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<bool> StoreExists(int storeId);
        Task<bool> BrandExists(int brandId);
        Task AddProduct(Product product);
        Task<Product> GetProductById(int productId);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int productId);
        Task RecoverProduct(int productId);
    }
}
