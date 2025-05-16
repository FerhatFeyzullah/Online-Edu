using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.WebUI.DTOs.CourseCategoryDTOs;
using OnlineEdu.WebUI.DTOs.CourseDTOs;
using OnlineEdu.WebUI.Helper;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly HttpClient _client = HttpClientHelper.CreateClient();

        public async Task CourseCategoryDropDown ()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategories");

            List<SelectListItem> categories = (from x in values
                                               select new SelectListItem 
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CourseCategoryId.ToString()
                                               }).ToList();   
            ViewBag.courseCategories = categories;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses");
            return View(values);
        }
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _client.DeleteAsync($"courses/{id}");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateCourse()
        {
            await CourseCategoryDropDown();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDto createCourseDto)
        {
            await _client.PostAsJsonAsync("courses", createCourseDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateCourse(int id)
        {
            await CourseCategoryDropDown();
            var value = await _client.GetFromJsonAsync<UpdateCourseDto>($"courses/{id}");
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            await _client.PutAsJsonAsync("courses", updateCourseDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("courses/ShowOnHome/" + id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("courses/DontShowOnHome/" + id);
            return RedirectToAction(nameof(Index));
        }
    }
}
