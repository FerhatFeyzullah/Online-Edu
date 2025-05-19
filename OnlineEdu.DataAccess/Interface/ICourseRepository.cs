using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Interface
{
    public interface ICourseRepository:IRepository<Course>
    {
        List<Course> GetCoursesWithCategory();
        List<Course> GetCoursesWithCategoryAndWithTeacher();
        List<Course> GetCoursesWithCategory(Expression<Func<Course,bool>> filter=null);
        List<Course> GetCoursesWithCategoryByTeacher(int id);
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
    }
   
}

