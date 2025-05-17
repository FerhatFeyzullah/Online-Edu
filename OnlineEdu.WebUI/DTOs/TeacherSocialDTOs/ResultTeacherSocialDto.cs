using OnlineEdu.Entity.Entities;

namespace OnlineEdu.WebUI.DTOs.TeacherSocialDTOs
{
    public class ResultTeacherSocialDto
    {
        public int TeacherSocialId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int TeacherId { get; set; }
        public AppUser Teacher { get; set; }
    }
}
