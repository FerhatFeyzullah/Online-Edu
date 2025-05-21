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

        public List<CourseRegister> GetAllWithCourseAndCategory(int id)
        {
            //return _context.CourseRegisters.Where(x=>x.AppUserId==id).Include(x => x.Course).ThenInclude(x => x.CourseCategory).ToList();

            var values = _context.CourseRegisters
    .Include(x => x.AppUser)
    .Include(x => x.Course).ThenInclude(x => x.CourseCategory)
    .Include(x => x.Course).ThenInclude(x => x.AppUser)
    .Where(x => x.AppUserId == id)
    .ToList();
            return values;

            //var values = _context.CourseRegisters.Where(x => x.AppUserId == id).Include(x => x.Course).ThenInclude(x => x.CourseCategory).Include(x => x.AppUser).ToList();


            //return values;


        }
    }
}
