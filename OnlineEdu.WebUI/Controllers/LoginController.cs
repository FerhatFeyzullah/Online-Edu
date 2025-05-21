using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.UserDTOs;
using OnlineEdu.WebUI.Services.UserService;

namespace OnlineEdu.WebUI.Controllers
{
    public class LoginController(IUserService _userService) : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDto userLoginDto)
        { 
             var userRole = await _userService.LoginAsync(userLoginDto);

            if (userRole == "Admin")
            {
                return RedirectToAction("Index", "Banner", new { area = "Admin" });
            }
            else if (userRole == "Teacher")
            {
                return RedirectToAction("Index", "MyCourse", new { area = "Teacher" });
            }
            else if (userRole == "Student")
            {
                return RedirectToAction("Index", "CourseRegister", new { area = "Student" });
            }

            else
            {
                ModelState.AddModelError("", "Hatalı Email veya Şifre.");
                return View();
            }
            return View();

        }

        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        } 
    }
}
