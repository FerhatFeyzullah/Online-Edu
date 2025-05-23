

using OnlineEdu.DTO.DTOs.TeacherSocialDTOs;

namespace OnlineEdu.DTO.DTOs.UserDTOs
{
    public class ResultJustUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }
        public List<WriterWithHisSocialMediaDto> TeacherSocials { get; set; }

    }
}
