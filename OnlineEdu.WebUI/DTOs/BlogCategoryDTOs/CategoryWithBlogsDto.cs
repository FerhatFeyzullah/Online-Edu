using OnlineEdu.WebUI.DTOs.BlogDTOs;

namespace OnlineEdu.WebUI.DTOs.BlogCategoryDTOs
{
    public class CategoryWithBlogsDto
    {
        public int BlogCategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<SimpleBlogDto> Blogs { get; set; }
    }
}
