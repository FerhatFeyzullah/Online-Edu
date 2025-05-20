using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineEdu.Business.Interface;
using OnlineEdu.DataAccess.Interface;
using OnlineEdu.DTO.DTOs.BlogCategoryDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Management
{
    public class BlogCategoryManager : GenericManager<BlogCategory>, IBlogCategoryService
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;
        private readonly IMapper _mapper;
        public BlogCategoryManager(IRepository<BlogCategory> _repository, IBlogCategoryRepository blogCategoryRepository, IMapper mapper) : base(_repository)
        {
            _blogCategoryRepository = blogCategoryRepository;
            _mapper = mapper;
        }

        public List<CategoryWithBlogsDto> AGetAllCategoryWithBlogs()
        {
            var entities = _blogCategoryRepository.GetAllCategoryWithBlogs();
            return _mapper.Map<List<CategoryWithBlogsDto>>(entities);
        }

        
    }
}
