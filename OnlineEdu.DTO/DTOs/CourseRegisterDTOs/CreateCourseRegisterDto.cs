using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.DTO.DTOs.CourseDTOs;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DTO.DTOs.CourseRegisterDTOs
{
    public class CreateCourseRegisterDto
    {
        public int AppUserId { get; set; }
        
        public int CourseId { get; set; }
   
    }
}
