using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.UserDTOs;
using OnlineEdu.WebUI.Helper;
using OnlineEdu.WebUI.Services.TokenService;
using OnlineEdu.WebUI.Services.UserService;

namespace OnlineEdu.WebUI.ViewComponents
{
    public class _HomeTeacherComponent(IUserService _userService):ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userService.Get3Teachers();
            return View(values);
        }
    }
}
