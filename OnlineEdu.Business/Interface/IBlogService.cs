using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.DTO.DTOs.BlogDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Interface
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> AGetBlogsWithCategory();
        List<ResultBlogDto> AGetBlogsByCategoryId(int id);
        BlogWithCategoryAndWriterDto AGetBlogsWithCategory(int id);
        List<Blog> AGetLast4BlogWithCategory();
        List<Blog> AGetBlogsWithCategoryByWriter(int id);
    }
    
}
