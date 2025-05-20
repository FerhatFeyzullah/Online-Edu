using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.DTO.DTOs.BlogCategoryDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Interface
{
    public interface IBlogCategoryRepository:IRepository<BlogCategory>
    {
        List<BlogCategory> GetAllCategoryWithBlogs();
    }
}
