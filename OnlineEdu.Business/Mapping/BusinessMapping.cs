using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineEdu.DTO.DTOs.AppUserDTOs;
using OnlineEdu.DTO.DTOs.BlogCategoryDTOs;
using OnlineEdu.DTO.DTOs.BlogDTOs;
using OnlineEdu.DTO.DTOs.CourseCategoryDTOs;
using OnlineEdu.DTO.DTOs.CourseDTOs;
using OnlineEdu.DTO.DTOs.CourseRegisterDTOs;
using OnlineEdu.DTO.DTOs.TeacherSocialDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Mapping
{
    public class BusinessMapping:Profile
    {
        public BusinessMapping()
        {
            CreateMap<BlogCategory, CategoryWithBlogsDto>().ReverseMap();
            CreateMap<Blog, SimpleBlogDto>().ReverseMap();

            CreateMap<Blog, BlogWithCategoryAndWriterDto>().ReverseMap();
            CreateMap<BlogCategory, ResultBlogCategoryDto>().ReverseMap();            
            CreateMap<TeacherSocial, WriterWithHisSocialMediaDto>().ReverseMap();
            CreateMap<AppUser, ResultBlogWithWriterDto>()
    .ForMember(dest => dest.TeacherSocial, opt => opt.MapFrom(src => src.TeacherSocials));

            CreateMap<CourseRegister, ResultCourseRegisterDto>().ReverseMap();
            CreateMap<AppUser, ResultAppUserDto>().ReverseMap();
            CreateMap<Course, ResultCourseDto>().ReverseMap();
            CreateMap<Course, ResultCourseForCourseRegister>().ReverseMap();
            CreateMap<Course, ResultCourseForCourseRegister>().ReverseMap();
            //.ForMember(dest => dest.CourseId, opt => opt.MapFrom(src => src.CourseId))
            //.ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.CourseName))
            //.ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            //.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            //.ForMember(dest => dest.IsShown, opt => opt.MapFrom(src => src.IsShown))
            //.ForMember(dest => dest.CourseCategoryId, opt => opt.MapFrom(src => src.CourseCategoryId))
            //.ForMember(dest => dest.CourseCategory, opt => opt.MapFrom(src => src.CourseCategory))
            //.ForAllOtherMembers(opt => opt.Ignore());




        }
    }
}
