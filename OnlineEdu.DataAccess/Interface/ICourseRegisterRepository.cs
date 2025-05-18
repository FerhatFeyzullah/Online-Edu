using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Interface
{
    public interface ICourseRegisterRepository:IRepository<CourseRegister>
    {
        List<CourseRegister> GetAllWithCourseAndCategory(Expression<Func<CourseRegister,bool>> Filter);
    }
}
