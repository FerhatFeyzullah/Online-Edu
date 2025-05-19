using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Interface;
using OnlineEdu.DTO.DTOs.BlogCategoryDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController(IGenericService<BlogCategory> _blogCategoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _blogCategoryService.AGetList();
            var mappedvalues = _mapper.Map<List<ResultBlogCategoryDto>>(values);
            return Ok(mappedvalues);
        }       

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var value = _blogCategoryService.AGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _blogCategoryService.ADelete(id);
            return Ok("Blog Kategorisi Silindi.");
        }
        [HttpPost]
        public IActionResult Create(CreateBlogCategoryDto createBlogCategoryDto)
        {
            var value = _mapper.Map<BlogCategory>(createBlogCategoryDto);
            _blogCategoryService.ACreate(value);
            return Ok("Blog Kategorisi Eklendi.");
        }
        [HttpPut]
        public IActionResult Update(UpdateBlogCategoryDto updateBlogCategoryDto)
        {
            var value = _mapper.Map<BlogCategory>(updateBlogCategoryDto);
            _blogCategoryService.AUpdate(value);
            return Ok("Blog Kategorisi Güncellendi.");
        }
    }
}
