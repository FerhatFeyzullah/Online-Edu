using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Interface;
using OnlineEdu.DTO.DTOs.CourseCategoryDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController(ICourseCategoryService _courseCategoryService,IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseCategoryService.AGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _courseCategoryService.AGetById(id);
            return Ok(value);
        }
        [AllowAnonymous]
        [HttpGet("GetActiveCategory")]
        public IActionResult GetActiveCategory()
        {
            var values = _courseCategoryService.AGetFilteredList(x=>x.IsShown==true);
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseCategoryService.ADelete(id);
            return Ok("Kurs Kategori Silme Basarili");
        }
        [HttpPost]
        public IActionResult Create(CreateCourseCategoryDto createCourseCategoryDto)
        {
            var value = _mapper.Map<CourseCategory>(createCourseCategoryDto);
            _courseCategoryService.ACreate(value);
            return Ok("Kurs Kategori Ekleme Basarili");
        }
        [HttpPut]
        public IActionResult Update(UpdateCourseCategoryDto updateCourseCategoryDto)
        {
            var value = _mapper.Map<CourseCategory>(updateCourseCategoryDto);
            _courseCategoryService.AUpdate(value);
            return Ok("Kurs Kategori Guncelleme Basarili");
        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _courseCategoryService.AShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor.");
        }

        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _courseCategoryService.ADontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor.");
        }
        [AllowAnonymous]
        [HttpGet("GetCourseCategoryCount")]
        public IActionResult GetCourseCategoryCount()
        {
            var value = _courseCategoryService.ACount();
            return Ok(value);
        }
    }
}
