using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Interface
{
    public interface ICourseCategoryService:IGenericService<CourseCategory>
    {
        void AShowOnHome(int id);

        void ADontShowOnHome(int id);
    }
}
