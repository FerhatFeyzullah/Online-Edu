using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Interface
{
    public interface ICourseService:IGenericService<Course>
    {
        List<Course> AGetCoursesWithCategory();
        List<Course> AGetCoursesWithCategoryAndWithTeacher();
        List<Course> AGetCoursesWithCategory(Expression<Func<Course, bool>> filter);
        List<Course> AGetCoursesWithCategoryByTeacher(int id);
        void AShowOnHome(int id);
        void ADontShowOnHome(int id);
    }
}
