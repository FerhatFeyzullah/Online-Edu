using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Interface;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        
        public BlogRepository(OnlineEduContext _context) : base(_context)
        { 
            
        }
        

        public List<Blog> GetBlogsWithCategory()
        {
            return _context.Blogs.Include(x => x.BlogCategory).ToList();
        }

        public List<Blog> GetBlogsWithCategoryByWriter(int id)
        {
            var values = _context.Blogs.Include(x => x.BlogCategory).ToList();
            var filtered = values.Where(x => x.WriterId == id).ToList();
            return filtered;
        }

        public List<Blog> GetLast4BlogWithCategory()
        {
            var values = _context.Blogs.Include(x=>x.BlogCategory).OrderByDescending(x => x.BlogId).Take(4).ToList();
            return values;
        }
    }
}
