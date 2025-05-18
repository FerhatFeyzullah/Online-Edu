using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.CourseDTOs;

namespace OnlineEdu.WebUI.DTOs.CourseRegisterDTOs
{
    public class ResultCourseRegisterDto
    {
        public int CourseRegisterId { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int CourseId { get; set; }
        public ResultCourseDto Course { get; set; }
    }
}
