using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.DTO.DTOs.CourseVideoDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Interface
{
    public interface ICourseVideoService:IGenericService<CourseVideo>
    {
        List<ResultCourseVideoDto> AGetVideoWithCourse();
        List<ResultCourseVideoDto> AGetFilteredListWithCourse(int id);
    }
}
