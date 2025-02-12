using StoreSphere.WebAPI.Models;

namespace StoreSphere.WebAPI.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> UserExists(string email);
        Task<User> GetUserByEmail(string email);
        Task AddUser(User user);
        Task UpdateUser(User user); // Add this method
    }
}