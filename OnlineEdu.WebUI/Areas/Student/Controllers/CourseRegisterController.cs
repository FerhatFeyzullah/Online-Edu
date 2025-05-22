using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.CourseDTOs;
using OnlineEdu.WebUI.DTOs.CourseRegisterDTOs;
using OnlineEdu.WebUI.DTOs.CourseVideoDTOs;
using OnlineEdu.WebUI.Helper;
using OnlineEdu.WebUI.Services.TokenService;

namespace OnlineEdu.WebUI.Areas.Student.Controllers
{
    [Authorize(Roles = "Student")]
    [Area("Student")]
    public class CourseRegisterController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public CourseRegisterController(IHttpClientFactory clientFactory, IMapper mapper, ITokenService tokenService)
        {
            _client = clientFactory.CreateClient("EduClient");
            _mapper = mapper;
            _tokenService = tokenService;
        }

 
        public async Task<IActionResult> Index()
        {
            var userId = _tokenService.GetUserId;
            var values = await _client.GetFromJsonAsync<List<ResultCourseRegisterDto>>("courseRegisters/GetMyCourses/" + userId);
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
            var userId = _tokenService.GetUserId;
            model.AppUserId = userId;

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
