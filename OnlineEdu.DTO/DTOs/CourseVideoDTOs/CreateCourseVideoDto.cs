using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DTO.DTOs.CourseVideoDTOs
{
    public class CreateCourseVideoDto
    {
        public int VideoNumber { get; set; }
        public string VideoName { get; set; }
        public string VideoUrl { get; set; }


        public int CourseId { get; set; }
    }
}
