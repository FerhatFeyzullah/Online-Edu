using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Interface;
using OnlineEdu.DTO.DTOs.BlogCategoryDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Repositories
{
    public class BlogCategoryRepository : GenericRepository<BlogCategory>, IBlogCategoryRepository
    {
      

        public BlogCategoryRepository(OnlineEduContext context) : base(context)
        {
           
        }

        public List<BlogCategory> GetAllCategoryWithBlogs()
        {
            return _context.BlogCategories.Include(x => x.Blogs).ToList();
        }

    }
}
