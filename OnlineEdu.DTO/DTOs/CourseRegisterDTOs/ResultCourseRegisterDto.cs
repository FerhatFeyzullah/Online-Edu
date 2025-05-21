using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.DTO.DTOs.AppUserDTOs;
using OnlineEdu.DTO.DTOs.CourseDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DTO.DTOs.CourseRegisterDTOs
{
    public class ResultCourseRegisterDto
    {
        public int CourseRegisterId { get; set; }

        public int AppUserId { get; set; }
        public ResultAppUserDto AppUser { get; set; }
        public int CourseId { get; set; }
        public ResultCourseForCourseRegister Course { get; set; }
    }
}

