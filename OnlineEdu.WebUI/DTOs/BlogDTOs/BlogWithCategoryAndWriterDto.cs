using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.DTO.DTOs.AppUserDTOs;
using OnlineEdu.DTO.DTOs.BlogCategoryDTOs;
using OnlineEdu.DTO.DTOs.TeacherSocialDTOs;
using OnlineEdu.WebUI.DTOs.BlogCategoryDTOs;

namespace OnlineEdu.WebUI.DTOs.BlogDTOs
{
    public class BlogWithCategoryAndWriterDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime BlogDate { get; set; }

        public int BlogCategoryId { get; set; }
        public BlogCategoryDto BlogCategory { get; set; }

        public int WriterId { get; set; }
        public ResultBlogWithWriterDto Writer { get; set; }
    }
}
