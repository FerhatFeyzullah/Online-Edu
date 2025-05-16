using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.UserDTOs;
using OnlineEdu.WebUI.Services.UserService;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoleAssignController(IUserService _userService, UserManager<AppUser> _userManager, RoleManager<AppRole> _roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _userService.GetAllUserAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userService.GetUserById(id);
            TempData["UserId"] = user.Id;

            var roles = await _roleManager.Roles.ToListAsync();

            var userRoles = await _userManager.GetRolesAsync(user);

            List<AssignRoleDto> AssignRoleList = new List<AssignRoleDto>();

            foreach (var role in roles)
            {
                var assignRoleDto = new AssignRoleDto();

                assignRoleDto.RoleId = role.Id;
                assignRoleDto.RoleName = role.Name;
                assignRoleDto.RoleExist = userRoles.Contains(role.Name);


                AssignRoleList.Add(assignRoleDto);
            }
            return View(AssignRoleList);

        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<AssignRoleDto> assignRoleList)
        {
            int userId = (int)TempData["UserId"];

            var user = await _userService.GetUserById(userId);

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

            return RedirectToAction("Index");
        }
    }
}
