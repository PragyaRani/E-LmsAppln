using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminAndInstructor.Microservice.Dto
{
    public class UpdateCourseDto
    {
        public string CourseName { get; set; }
        public string Tag { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public decimal Hours { get; set; }
        public int Ratings { get; set; }
    }
}
