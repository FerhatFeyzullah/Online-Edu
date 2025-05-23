using OnlineEdu.WebUI.DTOs.CourseCategoryDTOs;
using OnlineEdu.WebUI.DTOs.UserDTOs;


namespace OnlineEdu.WebUI.DTOs.CourseDTOs
{
    public class ResultCourseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsShown { get; set; }


        public int CourseCategoryId { get; set; }
        public ResultCourseCategoryDto CourseCategory { get; set; }


        public int AppUserId { get; set; }
        public ResultJustUserDto AppUser { get; set; }
    }
}
