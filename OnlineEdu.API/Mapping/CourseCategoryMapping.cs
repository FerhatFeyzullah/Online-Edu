using AutoMapper;
using OnlineEdu.DTO.DTOs.CourseCategoryDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class CourseCategoryMapping:Profile
    {
        public CourseCategoryMapping()
        {
            CreateMap<CourseCategory, CreateCourseCategoryDto>().ReverseMap();
            CreateMap<CourseCategory, UpdateCourseCategoryDto>().ReverseMap();
            CreateMap<CourseCategory, ResultCourseCategoryDto>().ReverseMap();
        }
    }
}
