using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Interface;
using OnlineEdu.DTO.DTOs.CourseRegisterDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseRegistersController(ICourseRegisterService _courseRegisterService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("GetMyCourses/{userId}")]
        public IActionResult GetMyCourses(int userId)
        {
            var values = _courseRegisterService.AGetAllWithCourseAndCategory(x => x.AppUserId == userId);
            var mappedValues = _mapper.Map<List<ResultCourseRegisterDto>>(values);
            return Ok(mappedValues);

        }
        [HttpPost]
        public IActionResult RegisterToCourse(CreateCourseRegisterDto model)
        {
            var value = _mapper.Map<CourseRegister>(model);
            _courseRegisterService.ACreate(value);
            return Ok("Kursa Kayit Basarili");
        }
        [HttpPut]
        public IActionResult UpdateCourseRegister(CreateCourseRegisterDto model)
        {
            var value = _mapper.Map<CourseRegister>(model);
            _courseRegisterService.AUpdate(value);
            return Ok("Kurs Kaydi Guncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _courseRegisterService.AGetById(id);
            var mappedValue = _mapper.Map<ResultCourseRegisterDto>(value);
            return Ok(mappedValue);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _courseRegisterService.ADelete(id);
            return Ok("Kurs Kaydi Silindi");
        }
    }
}
