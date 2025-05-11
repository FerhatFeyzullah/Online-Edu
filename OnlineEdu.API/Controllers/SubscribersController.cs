using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Interface;
using OnlineEdu.DTO.DTOs.SubscriberDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController(IGenericService<Subscriber> _subscriberService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _subscriberService.AGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _subscriberService.AGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _subscriberService.ADelete(id);
            return Ok("Abone silme Basarili");
        }
        [HttpPost]
        public IActionResult Create(CreateSubscriberDto createAboutDto)
        {
            var value = _mapper.Map<Subscriber>(createAboutDto);
            _subscriberService.ACreate(value);
            return Ok("Abone Ekleme Basarili");
        }
        [HttpPut]
        public IActionResult Update(UpdateSubscriberDto updateAboutDto)
        {
            var value = _mapper.Map<Subscriber>(updateAboutDto);
            _subscriberService.AUpdate(value);
            return Ok("Abone Guncelleme Basarili");
        }
    }
}
