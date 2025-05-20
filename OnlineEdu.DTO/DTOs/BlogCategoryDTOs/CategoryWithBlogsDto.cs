using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.DTO.DTOs.BlogDTOs;

namespace OnlineEdu.DTO.DTOs.BlogCategoryDTOs
{
    public class CategoryWithBlogsDto
    {
        public int BlogCategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<SimpleBlogDto> Blogs { get; set; }
    }
}
