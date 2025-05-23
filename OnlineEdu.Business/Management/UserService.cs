using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Business.Interface;
using OnlineEdu.DTO.DTOs.UserDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Management
{
    public class UserService(UserManager<AppUser> _userManager, SignInManager<AppUser> _singInManager,
        RoleManager<AppRole> _roleManager, IMapper _mapper) : IUserService
    {
        public Task<bool> AssignRoleAsync(List<AssignRoleDto> assignRoleDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateRoleAsync(UserRoleDto userRoleDto)
        {
            throw new NotImplementedException();
        }
        public async Task<IdentityResult> CreateUserAsync(RegisterDto RegisterDto)
        {

            var user = new AppUser()
            {
                FirstName = RegisterDto.FirstName,
                LastName = RegisterDto.LastName,
                UserName = RegisterDto.UserName,
                Email = RegisterDto.Email,
            };

            if (RegisterDto.Password != RegisterDto.ConfirmPassword)
            {
                return new IdentityResult();
            }

            var result = await _userManager.CreateAsync(user, RegisterDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Student");
                return result;
            }
            return result;

        }

        public async Task<List<ResultJustUserDto>> Get3Teachers()
        {

            var values = await _userManager.Users.Include(x => x.TeacherSocials).ToListAsync();
            var filtered = values.Where(x => _userManager.IsInRoleAsync(x, "Teacher").Result).OrderByDescending(x => x.Id).Take(3).ToList();
            return _mapper.Map<List<ResultJustUserDto>>(filtered);

        }

        public async Task<List<ResultJustUserDto>> GetAllTeachers()
        {
            var values = await _userManager.Users.Include(x => x.TeacherSocials).ToListAsync();
            var filtered = values.Where(x => _userManager.IsInRoleAsync(x, "Teacher").Result).ToList();
            return _mapper.Map<List<ResultJustUserDto>>(filtered);
        }

        public async Task<List<AppUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public Task<int> GetTeacherCount()
        {
            throw new NotImplementedException();
        }

        public async Task<ResultJustUserDto> GetUserById(int id)
        {
            var value = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ResultJustUserDto>(value);

        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<string> LoginAsync(LoginDto LoginDto)
        {
            var user = await _userManager.FindByEmailAsync(LoginDto.Email);
            if (user == null)
            {
                return null;
            }

            var result = await _singInManager.PasswordSignInAsync(user, LoginDto.Password, false, false);

            if (!result.Succeeded)
            {
                return null;
            }
            else
            {
                var IsAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                if (IsAdmin) { return "Admin"; }
                var IsTeacher = await _userManager.IsInRoleAsync(user, "Teacher");
                if (IsTeacher) { return "Teacher"; }
                var IsStudent = await _userManager.IsInRoleAsync(user, "Student");
                if (IsStudent) { return "Student"; }
            }
            return null;


        }

        public async Task LogoutAsync()
        {
            await _singInManager.SignOutAsync();
        }
    }
}
