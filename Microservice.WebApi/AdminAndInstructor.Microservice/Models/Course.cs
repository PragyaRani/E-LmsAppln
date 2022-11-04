﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AdminAndInstructor.Microservice.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public int Rating { get; set; }
        public string Author { get; set; }
        public DateTime Created = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
        public string Language { get; set; }
        public decimal Hours { get; set; }
        public Category Categories { get; set; }
        public Content Contents { get; set; }
    }
}
