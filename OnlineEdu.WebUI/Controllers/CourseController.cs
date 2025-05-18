using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseDTOs;
using OnlineEdu.WebUI.Helper;

namespace OnlineEdu.WebUI.Controllers
{
    public class CourseController : Controller
    {
        private readonly HttpClient _client = HttpClientHelper.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("Courses/GetCoursesWithCategoryAndWithTeacher");
            return View(values);
        }

        public async Task<IActionResult> GetCoursesByCategory(int id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("Courses/GetCoursesWithEverythingById/"+id);

            var category = (from x in values
                            select x.CourseCategory.CategoryName).FirstOrDefault();                            

            ViewBag.CategoryName = category;
            return View(values);
        }

    }
}
