using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Interface
{
    public interface ICourseCategoryRepository : IRepository<CourseCategory>
    {
       void ShowOnHome(int id);

       void DontShowOnHome(int id);

    }
   
}
