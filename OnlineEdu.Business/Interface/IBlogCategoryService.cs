using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.DTO.DTOs.BlogCategoryDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Interface
{
    public interface IBlogCategoryService:IGenericService<BlogCategory>
    {
    
        List<CategoryWithBlogsDto> AGetAllCategoryWithBlogs();
        
    }
}
