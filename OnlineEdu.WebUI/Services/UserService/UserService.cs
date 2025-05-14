using Microsoft.AspNetCore.Identity;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.UserDTOs;

namespace OnlineEdu.WebUI.Services.UserService
{
    public class UserService(UserManager<AppUser> _userManger, SignInManager<AppUser> _singInManager,
        RoleManager<AppRole> _roleManager) : IUserService
    {
        public Task<bool> AssignRoleAsync(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }
        public async Task<IdentityResult> CreateUserAsync(UserRegisterDto userRegisterDto)
        {

            var user = new AppUser()
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
            };

            if (userRegisterDto.Password != userRegisterDto.ConfirmPassword)
            {
                 return new IdentityResult();
            }

            return await _userManger.CreateAsync(user, userRegisterDto.Password);
        }
        

        public Task<bool> LoginAsync(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
