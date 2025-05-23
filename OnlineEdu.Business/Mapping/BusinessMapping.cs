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
using OnlineEdu.DTO.DTOs.UserDTOs;
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
            CreateMap<AppUser, ResultJustUserDto>().ReverseMap();
            CreateMap<Course, ResultCourseDto>().ReverseMap();
            CreateMap<Course, ResultCourseForCourseRegister>().ReverseMap();
            CreateMap<Course, ResultCourseForCourseRegister>().ReverseMap();
            




        }
    }
}
