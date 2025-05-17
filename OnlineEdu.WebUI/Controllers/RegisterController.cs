using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.UserDTOs;
using OnlineEdu.WebUI.Services.UserService;

namespace OnlineEdu.WebUI.Controllers
{
    public class RegisterController(IUserService _userService) : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterDto userRegisterDto)
        {
            var result = await _userService.CreateUserAsync(userRegisterDto);
            if (!result.Succeeded || !ModelState.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            return RedirectToAction("SignIn", "Login");
        }
    }
}
 