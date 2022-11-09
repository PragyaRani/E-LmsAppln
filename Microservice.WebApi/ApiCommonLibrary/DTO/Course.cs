using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiCommonLibrary.DTO
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public decimal Rating { get; set; }
        public string Author { get; set; }

        //public string Created =DateTime.Now.ToString();
        public string Language { get; set; }
        public decimal Hours { get; set; }
        public DateTime CreatedDate { get; }
        public DateTime UpdatedDate { get; }
        public Category Categories { get; set; }
        public Content Contents { get; set; }
        public Topic Topics { get; set; }
    }
    public class Notification
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EnrollDate { get; }
    }
}
