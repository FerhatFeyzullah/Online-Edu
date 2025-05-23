
using OnlineEdu.WebUI.DTOs.BlogDTOs;
using OnlineEdu.WebUI.DTOs.CourseDTOs;
using OnlineEdu.WebUI.DTOs.TeacherSocialDTOs;

namespace OnlineEdu.WebUI.DTOs.UserDTOs
{
    public class ResultJustUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<WriterWithHisSocialMediaDto> TeacherSocials { get; set; }

    }
}
