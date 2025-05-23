using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Interface;
using OnlineEdu.DTO.DTOs.BlogDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IMapper _mapper,IBlogService _blogService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _blogService.AGetBlogsWithCategory();           
            return Ok(values);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var blog = _blogService.AGetBlogsWithCategory(id);
            return Ok(blog);
        }
        [AllowAnonymous]
        [HttpGet("GetLast4Blogs")]
        public IActionResult GetLast4Blogs()
        {
            var values = _blogService.AGetLast4BlogWithCategory();
            var mappedvalues = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(mappedvalues);
        }
        [AllowAnonymous]
        [HttpGet("GetBlogsWithCategoryByWriter/{id}")]
        public IActionResult GetBlogsWithCategoryByWriter(int id)
        {
            var values = _blogService.AGetBlogsWithCategoryByWriter(id);
            var mappedavlues = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(mappedavlues);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _blogService.ADelete(id);
            return Ok("Blog Silindi");
        }

        [HttpPost]
        public  IActionResult CreateAsync(CreateBlogDto createBlogDto)
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
        [AllowAnonymous]
        [HttpGet("GetBlogCount")]
        public IActionResult GetBlogCount()
        {
            var value = _blogService.ACount();
            return Ok(value);
        }
        [AllowAnonymous]
        [HttpGet("GetBlogsByCategoryId/{id}")]
        public IActionResult GetBlogsByCategoryId(int id)
        {
            var value = _blogService.AGetBlogsByCategoryId(id);
            return Ok(value);
        }


    }
}
