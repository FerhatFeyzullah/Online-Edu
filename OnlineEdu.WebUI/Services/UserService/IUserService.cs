using Microsoft.AspNetCore.Identity;
using OnlineEdu.WebUI.DTOs.UserDTOs;
using OnlineEdu.WebUI.Models;

namespace OnlineEdu.WebUI.Services.UserService
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto);
        Task<string> LoginAsync(UserLoginDto userLoginDto);
        Task LogoutAsync();
        Task<bool> CreateRoleAsync(UserRoleDto userRoleDto);
        Task<bool> AssignRoleAsync(UserRoleDto userRoleDto);
        Task<List<UserViewModel>> GetAllUserAsync();
        Task<List<AssignRoleDto>> GetUserForRoleAssign(int id);        
        Task<List<ResultUserDto>> GetAllTeachers();
      
    }
}
