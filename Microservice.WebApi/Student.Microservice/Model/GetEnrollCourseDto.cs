using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Microservice.Model
{
    public class EnrollCourseDto
    {
        public string CourseName { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public decimal Hours { get; set; }
        public DateTime Created { get; set; }
        public int Rating { get; set; }
        public string Tag { get; set; }
    }
}
