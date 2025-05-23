namespace OnlineEdu.WebUI.DTOs.CourseVideoDTOs
{
    public class UpdateCourseVideoDto
    {
        public int CourseVideoId { get; set; }
        public int VideoNumber { get; set; }
        public string VideoName { get; set; }
        public string VideoUrl { get; set; }


        public int CourseId { get; set; }
    }
}
