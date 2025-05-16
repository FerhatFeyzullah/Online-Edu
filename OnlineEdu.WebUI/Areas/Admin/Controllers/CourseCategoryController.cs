using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseCategoryDTOs;
using OnlineEdu.WebUI.Helper;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CourseCategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientHelper.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategories");
            return View(values);
        }
        public async Task<IActionResult> DeleteCourseCategory(int id)
        {
            await _client.DeleteAsync($"courseCategories/{id}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateCourseCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseCategory(CreateCourseCategoryDto createCourseCategoryDto)
        {
            await _client.PostAsJsonAsync("courseCategories", createCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateCourseCategory(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateCourseCategoryDto>($"courseCategories/{id}");
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCourseCategory(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            await _client.PutAsJsonAsync("courseCategories", updateCourseCategoryDto);
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> ShowOnHome(int id) 
        {
            await _client.GetAsync("courseCategories/ShowOnHome/" + id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("courseCategories/DontShowOnHome/" + id);
            return RedirectToAction(nameof(Index));
        }
    }
}
