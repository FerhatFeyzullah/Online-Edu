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

        public async Task<string> LoginAsync(UserLoginDto userLoginDto)
        {
            var user = await _userManger.FindByEmailAsync(userLoginDto.Email);
            if (user == null)
            {
                return null;
            }

            var result = await _singInManager.PasswordSignInAsync(user, userLoginDto.Password, false, false);

            if (!result.Succeeded)
            {
                return null;
            }
            else 
            {
                var IsAdmin = await _userManger.IsInRoleAsync(user, "Admin");
                if (IsAdmin) { return "Admin"; }
                var IsTeacher = await _userManger.IsInRoleAsync(user, "Teacher");
                if (IsTeacher) { return "Teacher"; }
                var IsStudent = await _userManger.IsInRoleAsync(user, "Student");
                if (IsStudent) { return "Student"; }
            }
            return null;
                    

        }

        public Task<bool> LogoutAsync()
        {
            throw new NotImplementedException();
        }

       
    }
}
