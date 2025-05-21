using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineEdu.DTO.DTOs.AppUserDTOs;
using OnlineEdu.DTO.DTOs.CourseCategoryDTOs;
using OnlineEdu.DTO.DTOs.CourseDTOs;
using OnlineEdu.DTO.DTOs.CourseVideoDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Mapping
{
    public class CourseVideoMapping:Profile
    {
        public CourseVideoMapping()
        {
            CreateMap<CourseVideo, ResultCourseVideoDto>().ReverseMap();
            CreateMap<Course, ResultCourseDto>().ReverseMap();
            CreateMap<CourseCategory, ResultCourseCategoryDto>().ReverseMap();
            CreateMap<AppUser, ResultAppUserDto>().ReverseMap();
        }
    }
}
