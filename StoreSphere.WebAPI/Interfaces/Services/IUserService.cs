using StoreSphere.WebAPI.DTOs.UserDTOs;

namespace StoreSphere.WebAPI.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> Register(UserRegistrationDto userDto);
        Task<string> Login(LoginDto loginDto);
        Task<string> ChangePassword(ChangePasswordDto changePasswordDto);
    }
}
