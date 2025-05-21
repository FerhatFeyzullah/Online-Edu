using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineEdu.Business.Interface;
using OnlineEdu.DataAccess.Interface;
using OnlineEdu.DTO.DTOs.CourseVideoDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Management
{
    public class CourseVideoManager : GenericManager<CourseVideo>, ICourseVideoService
    {
        private readonly ICourseVideoRepository _courseVideoRepository;
        private readonly IMapper _mapper;
        public CourseVideoManager(IRepository<CourseVideo> _repository, ICourseVideoRepository courseVideoRepository, IMapper mapper) : base(_repository)
        {
            _courseVideoRepository = courseVideoRepository;
            _mapper = mapper;
        }

        public List<ResultCourseVideoDto> AGetFilteredListWithCourse(int id)
        {
           var values = _courseVideoRepository.GetFilteredListWithCourse(id);
            return _mapper.Map<List<ResultCourseVideoDto>>(values);
        }

        public List<ResultCourseVideoDto> AGetVideoWithCourse()
        {
            var values = _courseVideoRepository.GetVideoWithCourse();
            return _mapper.Map<List<ResultCourseVideoDto>>(values);

        }
    }
}
