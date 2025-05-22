using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.Helper;
using OnlineEdu.WebUI.Services.TokenService;

namespace OnlineEdu.WebUI.ViewComponents
{
    public class _HomeCounterComponent:ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeCounterComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.BlogCount = await _client.GetFromJsonAsync<int>("blogs/GetBlogCount");
            ViewBag.CourseCount = await _client.GetFromJsonAsync<int>("courses/GetCourseCount");
            ViewBag.CourseCategoryCount = await _client.GetFromJsonAsync<int>("courseCategories/GetCourseCategoryCount");
            ViewBag.TestimonialsCount = await _client.GetFromJsonAsync<int>("testimonials/GetTestimonialCount");
            return View();
        }
    }
}
