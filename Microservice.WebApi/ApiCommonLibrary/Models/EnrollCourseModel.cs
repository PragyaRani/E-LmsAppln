using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCommonLibrary.Models
{
    public class EnrollCourseModel
    {
        public string Student { get; set; }
        public DateTime EnrolleDate { get; set; }
        public string Course { get; set; }
        public int CourseId { get; set; }
    }
}
