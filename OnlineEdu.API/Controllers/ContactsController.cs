using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Interface;
using OnlineEdu.DTO.DTOs.ContactDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(IGenericService<Contact> _contactService, IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _contactService.AGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _contactService.AGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _contactService.ADelete(id);
            return Ok("Contact silme Basarili");
        }
        [HttpPost]
        public IActionResult Create(CreateContactDto createcontactDto)
        {
            var value = _mapper.Map<Contact>(createcontactDto);
            _contactService.ACreate(value);
            return Ok("Contact Ekleme Basarili");
        }
        [HttpPut]
        public IActionResult Update(UpdateContactDto updatecontactDto)
        {
            var value = _mapper.Map<Contact>(updatecontactDto);
            _contactService.AUpdate(value);
            return Ok("Contact Guncelleme Basarili");
        }
    }
}
