using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.UserDTOs;
using OnlineEdu.WebUI.Services.TokenService;

namespace OnlineEdu.WebUI.Areas.Student.Controllers
{
    [Authorize(Roles = "Student")]
    [Area("Student")]
    public class DashboardController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;
        public DashboardController(IHttpClientFactory clientFactory, ITokenService tokenService)
        {
            _client = clientFactory.CreateClient("EduClient");
            _tokenService = tokenService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _tokenService.GetUserId;
            var userValue = await _client.GetFromJsonAsync<ResultJustUserDto>("users/GetUserById/" + userId);

            return View(userValue);
        }
    }
}
