using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Interface;
using OnlineEdu.DTO.DTOs.TeacherSocialDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherSocialsController(IGenericService<TeacherSocial> _teacherSocialMedia, IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("GetTeacherSocialByFiltered/{id}")]
        public IActionResult GetTeacherSocialByFiltered(int id)
        {
            var values = _teacherSocialMedia.AGetFilteredList(x=>x.TeacherId==id);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _teacherSocialMedia.AGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teacherSocialMedia.ADelete(id);
            return Ok("Eğitmen Sosyal Meyası silme Basarili");
        }
        [HttpPost]
        public IActionResult Create(CreateTeacherSocialDto createTeacherSocialDto)
        {
            var value = _mapper.Map<TeacherSocial>(createTeacherSocialDto);
            _teacherSocialMedia.ACreate(value);
            return Ok("Eğitmen Sosyal Meyası Ekleme Basarili");
        }
        [HttpPut]
        public IActionResult Update(UpdateTeacherSocialDto updateTeacherSocialDto)
        {
            var value = _mapper.Map<TeacherSocial>(updateTeacherSocialDto);
            _teacherSocialMedia.AUpdate(value);
            return Ok("Eğitmen Sosyal Meyası Guncelleme Basarili");
        }
    }
}
