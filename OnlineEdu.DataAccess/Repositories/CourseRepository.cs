using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(OnlineEduContext context) : base(context)
        {
        }
      

        public List<Course> GetCoursesWithCategory()
        {
            return _context.Courses.Include(x => x.CourseCategory).ToList();
        }

        public void ShowOnHome(int id)
        {
            var value = _context.Courses.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }
        public void DontShowOnHome(int id)
        {
            var value = _context.Courses.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public List<Course> GetCoursesWithCategoryByTeacher(int id)
        {
            var values = _context.Courses.Include(x => x.CourseCategory).ToList();
            var filtreted = values.Where(x => x.AppUserId == id).ToList();
            return filtreted;
        }

        public List<Course> GetCoursesWithCategory(Expression<Func<Course, bool>> filter=null)
        {
            //Metot OverLoad (uuuuu)
            IQueryable<Course> values = _context.Courses.Include(x => x.CourseCategory).Include(x=>x.AppUser).AsQueryable();
            if (filter != null)
            {
                values = values.Where(filter);
            }
           return values.ToList();
        }

        public List<Course> GetCoursesWithCategoryAndWithTeacher()
        {
            var values = _context.Courses.Include(x => x.CourseCategory).Include(x=>x.AppUser).ToList();
            
            return values;
        }
    }
}
