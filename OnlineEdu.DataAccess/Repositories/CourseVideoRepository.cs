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
    public class CourseVideoRepository : GenericRepository<CourseVideo>, ICourseVideoRepository
    {
        public CourseVideoRepository(OnlineEduContext context) : base(context)
        {
        }

        public List<CourseVideo> GetFilteredListWithCourse(int id)
        {
            var values = _context.CourseVideos.Include(x => x.Course).ToList();
            var filtered = values.Where(x=>x.Course.CourseId==id).ToList();
            return filtered;
        }

        public List<CourseVideo> GetVideoWithCourse()
        {
            var values = _context.CourseVideos.Include(x => x.Course).ThenInclude(x=>x.CourseCategory).Include(x=>x.Course).ThenInclude(x => x.AppUser).ToList();
            return values;

        }
    }
}

