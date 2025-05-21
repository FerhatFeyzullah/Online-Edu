using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Interface
{
    public interface ICourseVideoRepository:IRepository<CourseVideo>
    {
        List<CourseVideo> GetVideoWithCourse();
        List<CourseVideo> GetFilteredListWithCourse(int id);
    }
}
