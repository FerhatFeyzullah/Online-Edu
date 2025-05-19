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
    public class CourseManager : GenericManager<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseManager(IRepository<Course> _repository, ICourseRepository courseRepository) : base(_repository)
        {
            _courseRepository = courseRepository;
        }

        public void ADontShowOnHome(int id)
        {
            _courseRepository.DontShowOnHome(id);
        }

        public List<Course> AGetCoursesWithCategory()
        {
            return _courseRepository.GetCoursesWithCategory();
        }

        public List<Course> AGetCoursesWithCategory(Expression<Func<Course, bool>> filter=null)
        {
            return _courseRepository.GetCoursesWithCategory(filter);
        }

        public List<Course> AGetCoursesWithCategoryAndWithTeacher()
        {
            return _courseRepository.GetCoursesWithCategoryAndWithTeacher();
        }

        public List<Course> AGetCoursesWithCategoryByTeacher(int id)
        {
            return _courseRepository.GetCoursesWithCategoryByTeacher(id);
        }

        public void AShowOnHome(int id)
        {
            _courseRepository.ShowOnHome(id);
        }
    }
}
