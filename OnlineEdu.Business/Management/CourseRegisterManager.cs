using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Business.Interface;
using OnlineEdu.DataAccess.Interface;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Management
{
    public class CourseRegisterManager : GenericManager<CourseRegister>, ICourseRegisterService
    {
        private readonly ICourseRegisterRepository _courseRegisterRepository;
        public CourseRegisterManager(IRepository<CourseRegister> _repository, ICourseRegisterRepository courseRegisterRepository) : base(_repository)
        {
            _courseRegisterRepository = courseRegisterRepository;
        }

        public List<CourseRegister> AGetAllWithCourseAndCategory(Expression<Func<CourseRegister, bool>> Filter)
        {
            return _courseRegisterRepository.GetAllWithCourseAndCategory(Filter);
        }
    }
}
