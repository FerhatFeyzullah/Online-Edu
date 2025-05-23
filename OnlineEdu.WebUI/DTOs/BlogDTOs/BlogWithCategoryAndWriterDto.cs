using OnlineEdu.WebUI.DTOs.BlogCategoryDTOs;
using OnlineEdu.WebUI.DTOs.UserDTOs;

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
