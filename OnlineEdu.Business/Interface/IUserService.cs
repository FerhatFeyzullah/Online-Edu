using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OnlineEdu.DTO.DTOs.UserDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Interface
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(RegisterDto userRegisterDto);

        Task<string> LoginAsync(LoginDto userLoginDto);
        Task LogoutAsync();

        Task<bool> CreateRoleAsync(UserRoleDto userRoleDto);

        Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto);
        Task<List<AppUser>> GetAllUsersAsync();

        Task<List<ResultJustUserDto>> Get3Teachers();

        Task<AppUser> GetUserByIdAsync(int id);
        Task<ResultJustUserDto> GetUserById(int id);

        Task<int> GetTeacherCount();

        Task<List<ResultJustUserDto>> GetAllTeachers();
    }
}
