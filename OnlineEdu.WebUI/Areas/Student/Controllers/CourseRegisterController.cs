using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.CourseDTOs;
using OnlineEdu.WebUI.DTOs.CourseRegisterDTOs;
using OnlineEdu.WebUI.DTOs.CourseVideoDTOs;
using OnlineEdu.WebUI.Helper;

namespace OnlineEdu.WebUI.Areas.Student.Controllers
{
    [Authorize(Roles = "Student")]
    [Area("Student")]
    public class CourseRegisterController(UserManager<AppUser> _userManager, IMapper _mapper) : Controller
    {
        private readonly HttpClient _client = HttpClientHelper.CreateClient();




        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = await _client.GetFromJsonAsync<List<ResultCourseRegisterDto>>("courseRegisters/GetMyCourses/" + user.Id);
            return View(values);
        }

        public async Task<IActionResult> RegisterCourse()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses/GetCoursesWithCategoryAndWithTeacher");
            var maapedValues = _mapper.Map<List<ResultCourseDto>>(values);
            ViewBag.Courses = maapedValues;
            return View();



        }
        [HttpPost]
        public async Task<IActionResult> RegisterCourse(CreateCourseRegisterDto model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            model.AppUserId = user.Id;

            await _client.PostAsJsonAsync("courseRegisters", model);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> GetCourseVideo(int id)
        { 
            var values = await _client.GetFromJsonAsync<List<ResultCourseVideoDto>>("courseVideos/GetVideosByCourseId/" + id);     
            ViewBag.CourseName = values.Select(x => x.Course.CourseName).FirstOrDefault();
            return View(values);
        }

    }
}
