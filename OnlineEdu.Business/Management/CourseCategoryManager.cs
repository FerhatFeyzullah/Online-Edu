using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Business.Interface;
using OnlineEdu.DataAccess.Interface;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Business.Management
{
    public class CourseCategoryManager:GenericManager<CourseCategory>, ICourseCategoryService
    {
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        public CourseCategoryManager(IRepository<CourseCategory> _repository, ICourseCategoryRepository courseCategoryRepository) : base(_repository)
        {
            _courseCategoryRepository = courseCategoryRepository;
        }

        public void AShowOnHome(int id)
        {
            _courseCategoryRepository.ShowOnHome(id);
        }
        public void ADontShowOnHome(int id)
        {
           _courseCategoryRepository.DontShowOnHome(id);
        }
    }
   
}
