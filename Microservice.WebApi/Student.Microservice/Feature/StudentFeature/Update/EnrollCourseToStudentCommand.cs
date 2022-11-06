using ApiCommonLibrary.DTO;
using MediatR;
using Student.Microservice.Data;
using Student.Microservice.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Microservice.Feature.StudentFeature.Update
{
    public class EnrollCourseToStudentCommand: IRequest<int>
    {
        [Required(ErrorMessage = "student email is required")]
        public string StudEmail { get; set; }

        public int EnrollCourseId { get; set; }
        //public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Author { get; set; }
        public class EnrollCourseToStudentCommandHandler : IRequestHandler<EnrollCourseToStudentCommand, int>
        {
            private readonly DataContext dataContext; 
            public EnrollCourseToStudentCommandHandler(DataContext _dataContext)
            {
                dataContext = _dataContext;
            }
            public async Task<int> Handle(EnrollCourseToStudentCommand request, CancellationToken cancellationToken)
            {
                EStudent student = dataContext.Students.Where(s => s.Email.ToLower() == request.StudEmail.ToLower()).FirstOrDefault();
                Course course = dataContext.Course.Where(c => (c.CourseId == request.EnrollCourseId) ||
                (c.Name.ToLower() == request.CourseName.ToLower() && c.Author == request.Author.ToLower())).FirstOrDefault();
                if(course == null || student == null)
                {
                    return default;
                }
                var studentandcourseExist = dataContext.StudentCourse.Where(sc => sc.EnrolledStudent.UserId == student.UserId && 
                            sc.Course.CourseId == course.CourseId).FirstOrDefault();
                if(studentandcourseExist != null)
                {
                    return studentandcourseExist.Id;
                }

                StudentCourse sc = new StudentCourse { EnrolledStudent = student, Course = course };
                dataContext.StudentCourse.Add(sc);
                await dataContext.SaveChangesAsync();
                return sc.Id;
            }
        }
    }
}
