using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Interface;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Repositories
{
    public class CourseRegisterRepository : GenericRepository<CourseRegister>, ICourseRegisterRepository
    {
        public CourseRegisterRepository(OnlineEduContext context) : base(context)
        {
        }

        public List<CourseRegister> GetAllWithCourseAndCategory(Expression<Func<CourseRegister, bool>> Filter)
        {
            return _context.CourseRegisters.Where(Filter).Include(x => x.Course).ThenInclude(x => x.CourseCategory).ToList();

        }
    }
}
