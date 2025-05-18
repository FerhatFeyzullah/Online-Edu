using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Interface
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> AGetBlogsWithCategory();
        List<Blog> AGetLast4BlogWithCategory();
        List<Blog> AGetBlogsWithCategoryByWriter(int id);
    }
    
}
