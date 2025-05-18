using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Interface
{
    public interface ICourseRegisterService:IGenericService<CourseRegister>
    {
        List<CourseRegister> AGetAllWithCourseAndCategory(Expression<Func<CourseRegister, bool>> Filter);

    }
}
