

using OnlineEdu.WebUI.DTOs.TeacherSocialDTOs;

namespace OnlineEdu.WebUI.DTOs.UserDTOs
{
    public class ResultBlogWithWriterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }

        public List<WriterWithHisSocialMediaDto> TeacherSocial { get; set; }
    }
}
