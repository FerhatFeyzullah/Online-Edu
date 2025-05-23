using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.DTO.DTOs.TeacherSocialDTOs;

namespace OnlineEdu.DTO.DTOs.UserDTOs
{
    public class ResultUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }

        public List<WriterWithHisSocialMediaDto> TeacherSocial { get; set; }
    }
}
