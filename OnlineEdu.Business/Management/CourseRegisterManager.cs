using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineEdu.Business.Interface;
using OnlineEdu.DataAccess.Interface;
using OnlineEdu.DTO.DTOs.CourseRegisterDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Management
{
    public class CourseRegisterManager : GenericManager<CourseRegister>, ICourseRegisterService
    {
        private readonly ICourseRegisterRepository _courseRegisterRepository;
        private readonly IMapper _mapper;
        public CourseRegisterManager(IRepository<CourseRegister> _repository, ICourseRegisterRepository courseRegisterRepository, IMapper mapper) : base(_repository)
        {
            _courseRegisterRepository = courseRegisterRepository;
            _mapper = mapper;
        }

        public List<ResultCourseRegisterDto> AGetAllWithCourseAndCategory(int id)
        {
            var values = _courseRegisterRepository.GetAllWithCourseAndCategory(id);
            return _mapper.Map<List<ResultCourseRegisterDto>>(values);
        }

        
    }
}
