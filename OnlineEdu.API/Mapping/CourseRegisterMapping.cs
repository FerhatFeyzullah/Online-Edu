using AutoMapper;
using OnlineEdu.DTO.DTOs.CourseRegisterDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class CourseRegisterMapping:Profile
    {
        public CourseRegisterMapping()
        {
            CreateMap<CourseRegister,ResultCourseRegisterDto>().ReverseMap();
            CreateMap<CourseRegister,CreateCourseRegisterDto>().ReverseMap();
            CreateMap<CourseRegister,UpdateCourseRegisterDto>().ReverseMap();
        }
    }
}
