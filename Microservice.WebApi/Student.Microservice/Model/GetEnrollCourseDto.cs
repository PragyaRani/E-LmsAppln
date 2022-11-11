using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Microservice.Model
{
    public class EnrollCourseDto
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public decimal Hours { get; set; }
        public string Created { get; set; }
        public decimal Rating { get; set; }
        public string Tag { get; set; }
    }
}
