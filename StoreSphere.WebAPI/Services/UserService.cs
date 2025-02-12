using Microsoft.IdentityModel.Tokens;
using StoreSphere.WebAPI.DTOs.UserDTOs;
using StoreSphere.WebAPI.Interfaces.Repositories;
using StoreSphere.WebAPI.Interfaces.Services;
using StoreSphere.WebAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoreSphere.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        private readonly EmailService _emailService;

        public UserService(IUserRepository userRepository, IConfiguration config, EmailService emailService)
        {
            _userRepository = userRepository;
            _config = config;
            _emailService = emailService;
        }


        public async Task<string> Register(UserRegistrationDto userDto)
        {
            if (await _userRepository.UserExists(userDto.Email))
                throw new Exception("Email already exists.");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PasswordHash = passwordHash,
                IsEmailConfirmed = false,
                ProfilePictureURL = userDto.ProfilePictureURL
            };

            await _userRepository.AddUser(user);

            // Send email confirmation
            var confirmationLink = $"https://yourdomain.com/confirm-email?userId={user.UserID}";
            await _emailService.SendEmailAsync(user.Email, "Confirm Your Email", $"Please confirm your email by clicking <a href='{confirmationLink}'>here</a>.");

            return "User registered successfully.";
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmail(loginDto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials.");

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: new[] { new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()) },
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var user = await _userRepository.GetUserByEmail(changePasswordDto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(changePasswordDto.OldPassword, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials.");

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(changePasswordDto.NewPassword);
            await _userRepository.UpdateUser(user); // Use the new UpdateUser method

            return "Password changed successfully.";
        }
    }
}