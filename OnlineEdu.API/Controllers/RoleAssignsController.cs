using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Business.Interface;
using OnlineEdu.DTO.DTOs.UserDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleAssignsController(IUserService _userService, UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers() 
        {
            var users = await _userService.GetAllUsersAsync();
            var userViewModels = new List<UserListDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                userViewModels.Add(new UserListDto
                {
                    Id = user.Id,
                    NameSurname = $"{user.FirstName} {user.LastName}",
                    UserName = user.UserName,
                    Roles = roles.ToList()
                });
            }


            return Ok(userViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserForRoleAssign(int id) 
        {
            var user = await _userService.GetUserByIdAsync(id);
            

            var roles = await _roleManager.Roles.ToListAsync();

            var userRoles = await _userManager.GetRolesAsync(user);

            List<AssignRoleDto> AssignRoleList = new List<AssignRoleDto>();

            foreach (var role in roles)
            {
                var assignRoleDto = new AssignRoleDto();

                assignRoleDto.UserId = user.Id;
                assignRoleDto.RoleId = role.Id;
                assignRoleDto.RoleName = role.Name;
                assignRoleDto.RoleExist = userRoles.Contains(role.Name);


                AssignRoleList.Add(assignRoleDto);
            }
            return Ok(AssignRoleList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> assignRoleList)
        {
            int userId = assignRoleList.Select(x=>x.UserId).FirstOrDefault();

            var user = await _userService.GetUserByIdAsync(userId);

            foreach (var item in assignRoleList)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return Ok("Rol Atama Basarili");
        }
    }
}
