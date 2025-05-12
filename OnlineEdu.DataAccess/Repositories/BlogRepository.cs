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
        private readonly OnlineEduContext _eduContext;
        public BlogRepository(OnlineEduContext _context) : base(_context)
        { 
            _eduContext = _context;
        }
        

        public List<Blog> GetBlogsWithCategory()
        {
            return _eduContext.Blogs.Include(x => x.BlogCategory).ToList();
        }
    }
}
