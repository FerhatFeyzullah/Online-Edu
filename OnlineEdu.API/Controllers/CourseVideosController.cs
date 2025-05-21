using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Interface;
using OnlineEdu.DTO.DTOs.CourseVideoDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseVideosController(ICourseVideoService _courseVideoService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseVideoService.AGetVideoWithCourse();
            return Ok(values);
        }
        [HttpGet("GetVideosByCourseId/{id}")]
        public IActionResult GetVideosByCourseId(int id)
        {
            var value = _courseVideoService.AGetFilteredListWithCourse(id);
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _courseVideoService.AGetById(id);
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseVideoService.ADelete(id);
            return Ok("CourseVideo silme Basarili");
        }
        [HttpPost]
        public IActionResult Create(CreateCourseVideoDto createCourseVideoDto)
        {
            var value = _mapper.Map<CourseVideo>(createCourseVideoDto);
            _courseVideoService.ACreate(value);
            return Ok("CourseVideo Ekleme Basarili");
        }
        [HttpPut]
        public IActionResult Update(UpdateCourseVideoDto updateCourseVideoDto)
        {
            var value = _mapper.Map<CourseVideo>(updateCourseVideoDto);
            _courseVideoService.AUpdate(value);
            return Ok("CourseVideo Guncelleme Basarili");
        }
    }
}
