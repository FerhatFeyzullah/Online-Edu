using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineEdu.Business.Interface;
using OnlineEdu.DataAccess.Interface;
using OnlineEdu.DTO.DTOs.BlogDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Management
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        public BlogManager(IRepository<Blog> _repository, IBlogRepository blogRepository, IMapper mapper) : base(_repository)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public List<ResultBlogDto> AGetBlogsByCategoryId(int id)
        {
            var blogs =  _blogRepository.GetBlogsByCategoryId(id);
            return _mapper.Map<List<ResultBlogDto>>(blogs);
        }

        public List<Blog> AGetBlogsWithCategory()
        {
            return _blogRepository.GetBlogsWithCategory();
        }

        public BlogWithCategoryAndWriterDto AGetBlogsWithCategory(int id)
        {
            var blog = _blogRepository.GetBlogsWithCategory(id);
            return _mapper.Map<BlogWithCategoryAndWriterDto>(blog);
        }

        public List<Blog> AGetBlogsWithCategoryByWriter(int id)
        {
            return _blogRepository.GetBlogsWithCategoryByWriter(id);
        }

        public List<Blog> AGetLast4BlogWithCategory()
        {
            return _blogRepository.GetLast4BlogWithCategory();
        }
    }

}
