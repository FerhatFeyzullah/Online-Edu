using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.UserDTOs;
using OnlineEdu.WebUI.Services.UserService;

namespace OnlineEdu.WebUI.Controllers
{
    public class TeacherController : Controller
    {
        private readonly HttpClient _client;

        public TeacherController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultJustUserDto>>("users/GetAllTeacher");
            return View(values);
        }
    }
}
