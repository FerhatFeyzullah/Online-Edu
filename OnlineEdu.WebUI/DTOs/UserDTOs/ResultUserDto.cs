
using OnlineEdu.WebUI.DTOs.TeacherSocialDTOs;

namespace OnlineEdu.WebUI.DTOs.UserDTOs
{
    public class ResultUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }
        public List<ResultTeacherSocialDto> TeacherSocials { get; set; }
    }
}
