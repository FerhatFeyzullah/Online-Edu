using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.CourseCategoryDTOs;
using OnlineEdu.WebUI.DTOs.CourseDTOs;
using OnlineEdu.WebUI.DTOs.CourseVideoDTOs;
using OnlineEdu.WebUI.Helper;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Area("Teacher")]
    public class MyCourseController : Controller
    {
        private readonly HttpClient _client = HttpClientHelper.CreateClient();
        private readonly UserManager<AppUser> _userManager;

        public MyCourseController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task CategoryDropDown()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoryDto>>("courseCategories");

            List<SelectListItem> categories = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CourseCategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
        }
        public async Task<IActionResult> Index(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>($"courses/GetCourseWithTeacherId/{user.Id}");
            return View(values);
        }

        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _client.DeleteAsync($"courses/{id}");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateCourse()
        {
            await CategoryDropDown();
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseDto createCourseDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            createCourseDto.AppUserId = user.Id;
            createCourseDto.IsShown = false;

            await _client.PostAsJsonAsync("courses", createCourseDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateCourse(int id)
        {
            await CategoryDropDown();
            var values = await _client.GetFromJsonAsync<UpdateCourseDto>($"courses/{id}");

            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            await _client.PutAsJsonAsync("courses", updateCourseDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetCourseVideo(int id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseVideoDto>>("courseVideos/GetVideosByCourseId/" + id);
            TempData["CourseId"] = id;
            ViewBag.CName = values.Select(x => x.Course.CourseName).FirstOrDefault();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateVideo()
        {
            var courseId = TempData["CourseId"];
            var course = await _client.GetFromJsonAsync<ResultCourseDto>($"courses/{courseId}");
            ViewBag.CourseName = course.CourseName;
            ViewBag.CourseId = course.CourseId;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateVideo(CreateCourseVideoDto createCourseVideoDto)
        {
            await _client.PostAsJsonAsync("courseVideos", createCourseVideoDto);
            return RedirectToAction("Index");
        }

    }
}
