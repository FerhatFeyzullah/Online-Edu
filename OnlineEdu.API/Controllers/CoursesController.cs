using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Interface;
using OnlineEdu.DTO.DTOs.CourseDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController(ICourseService _courseService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseService.AGetCoursesWithCategory();
            var categories = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _courseService.AGetById(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseService.ADelete(id);
            return Ok("Kurs Silme Basarili");
        }
        [HttpPost]
        public IActionResult Create(CreateCourseDto createCourseDto)
        {
            var value = _mapper.Map<Course>(createCourseDto);
            _courseService.ACreate(value);
            return Ok("Kurs Ekleme Basarili");
        }
        [HttpPut]
        public IActionResult Update(UpdateCourseDto updateCourseDto)
        {
            var value = _mapper.Map<Course>(updateCourseDto);
            _courseService.AUpdate(value);
            return Ok("Kurs Guncelleme Basarili");
        }
        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _courseService.AShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor.");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _courseService.ADontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor.");
        }
    }
}
