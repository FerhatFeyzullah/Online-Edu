using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.UserDTOs;

namespace OnlineEdu.WebUI.ViewComponents
{
    public class _HomeTeacherComponent:ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeTeacherComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultJustUserDto>>("users/Get3Teachers");
            return View(values);
        }
    }
}
