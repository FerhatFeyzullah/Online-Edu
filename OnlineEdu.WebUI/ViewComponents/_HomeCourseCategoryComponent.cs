using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseCategoryDTOs;
using OnlineEdu.WebUI.Helper;

namespace OnlineEdu.WebUI.ViewComponents
{
    public class _HomeCourseCategoryComponent:ViewComponent
    {
        private readonly HttpClient _client = HttpClientHelper.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategories/GetActiveCategory");
            return View(values);
        }
    }
}
