using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Interface;
using OnlineEdu.DTO.DTOs.BlogDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IGenericService<Blog> _blogService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var blogs = _blogService.AGetList();
            return Ok(blogs);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var blog = _blogService.AGetById(id);
            return Ok(blog);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _blogService.ADelete(id);
            return Ok("Blog Silindi");
        }
        [HttpPost]
        public IActionResult Create(CreateBlogDto createBlogDto)
        {
            var value = _mapper.Map<Blog>(createBlogDto);
            _blogService.ACreate(value);
            return Ok("Blog Ekleme Basarili.");
        }
        [HttpPut]
        public IActionResult Update(UpdateBlogDto updateBlogDto)
        {
            var value = _mapper.Map<Blog>(updateBlogDto);
            _blogService.AUpdate(value);
            return Ok("Blog Guncelleme Basarili.");
        }
        
    }
}
