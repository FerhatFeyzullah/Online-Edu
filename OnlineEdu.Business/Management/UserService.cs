using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OnlineEdu.Business.Interface;
using OnlineEdu.DTO.DTOs.UserDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Management
{
    public class UserService : IUserService
    {
        public Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateUserAsync(RegisterDto userRegisterDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultJustUserDto>> Get4Teachers()
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultJustUserDto>> GetAllTeachers()
        {
            throw new NotImplementedException();
        }

        public Task<List<AppUser>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTeacherCount()
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> LoginAsync(LoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
