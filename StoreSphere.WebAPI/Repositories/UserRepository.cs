using Microsoft.EntityFrameworkCore;
using StoreSphere.WebAPI.Interfaces.Repositories;
using StoreSphere.WebAPI.Models;

namespace StoreSphere.WebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreSphereContext _context;

        public UserRepository(StoreSphereContext context)
        {
            _context = context;
        }

        public async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user); // Update the user entity
            await _context.SaveChangesAsync();
        }
    }
}