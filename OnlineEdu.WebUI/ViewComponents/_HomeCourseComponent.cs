using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseDTOs;
using OnlineEdu.WebUI.Helper;

namespace OnlineEdu.WebUI.ViewComponents
{
    public class _HomeCourseComponent:ViewComponent
    {
        private readonly HttpClient _client = HttpClientHelper.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses/GetActiveCourse");
            return View(values);
        }
    }
}
