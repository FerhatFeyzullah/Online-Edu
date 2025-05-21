using AutoMapper;
using OnlineEdu.DTO.DTOs.CourseVideoDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class CourseVideoMapping:Profile
    {
        public CourseVideoMapping()
        {
            CreateMap<CourseVideo,ResultCourseVideoDto>().ReverseMap();
            CreateMap<CourseVideo,UpdateCourseVideoDto>().ReverseMap();
            CreateMap<CourseVideo,CreateCourseVideoDto>().ReverseMap();
        }
    }
}
