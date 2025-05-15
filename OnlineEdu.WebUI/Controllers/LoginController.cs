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
             var userResult = await _userService.LoginAsync(userLoginDto);

            if (userResult == "Admin")
            {
                RedirectToAction("Index", "Banner", new { area = "Admin" });
            }
            if (userResult == "Teacher")
            {
                RedirectToAction("Index", "MyCourse", new { area = "Teacher" });
            }
            if (userResult == "Student")
            {
                RedirectToAction("Index", "CourseRegister", new { area = "Student" });
            }

            else
            {
                ModelState.AddModelError("", "Hatalı Email veya Şifre.");
                return View();
            }
            return View();

        }
    }
}
