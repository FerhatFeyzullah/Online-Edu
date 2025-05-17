using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOs.BlogCategoryDTOs;

namespace OnlineEdu.WebUI.DTOs.BlogDTOs
{
    public class ResultBlogDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime BlogDate { get; set; }

        public int BlogCategoryId { get; set; }
        public ResultBlogCategoryDto BlogCategory { get; set; }

        public int WriterId { get; set; }
        public AppUser Writer { get; set; }
    }
}
