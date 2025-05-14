using Microsoft.AspNetCore.Identity;
using OnlineEdu.WebUI.DTOs.UserDTOs;

namespace OnlineEdu.WebUI.Services.UserService
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto);
        Task<bool> LoginAsync(UserLoginDto userLoginDto);
        Task<bool> LogoutAsync();
        Task<bool> CreateRoleAsync(UserRoleDto userRoleDto);
        Task<bool> AssignRoleAsync(UserRoleDto userRoleDto);
    }
}
