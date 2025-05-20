using AutoMapper;
using OnlineEdu.DTO.DTOs.BlogCategoryDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class BlogCategoryMapping:Profile
    {
        public BlogCategoryMapping()
        {
            CreateMap<BlogCategory,CreateBlogCategoryDto>().ReverseMap();
            CreateMap<BlogCategory,UpdateBlogCategoryDto>().ReverseMap();
            CreateMap<BlogCategory,ResultBlogCategoryDto>().ReverseMap();
            CreateMap<BlogCategory, CategoryWithBlogsDto>().ReverseMap();

        }
    }
}
