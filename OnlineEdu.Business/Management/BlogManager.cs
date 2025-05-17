using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Business.Interface;
using OnlineEdu.DataAccess.Interface;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Management
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogManager(IRepository<Blog> _repository, IBlogRepository blogRepository) : base(_repository)
        {
            _blogRepository = blogRepository;
        }

        public List<Blog> AGetBlogsWithCategory()
        {
            return _blogRepository.GetBlogsWithCategory();
        }

        public List<Blog> AGetBlogsWithCategoryByWriter(int id)
        {
            return _blogRepository.GetBlogsWithCategoryByWriter(id);
        }
    }

}
