using MediatR;
using Microsoft.EntityFrameworkCore;
using Student.Microservice.Data;
using Student.Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Microservice.Feature.StudentFeature.Query
{
    public class GetEnrollCoursebyStudent:IRequest<IEnumerable<EnrollCourseDto>>
    {
       public int Id { get; set; }

        public class GetEnrollCoursebyStudentHandler : IRequestHandler<GetEnrollCoursebyStudent, IEnumerable<EnrollCourseDto>>
        {
            public readonly DataContext context;
            public GetEnrollCoursebyStudentHandler(DataContext _context)
            {
                context = _context;
            }
            public async Task<IEnumerable<EnrollCourseDto>> Handle(GetEnrollCoursebyStudent request, CancellationToken cancellationToken)
            {
                var data = await context.StudentCourse.Where(sc => sc.EStudent.StudentId == request.Id)
                    .Join(context.Course, sc => sc.Course.CourseId, 
                    c => c.CourseId,
                    (studCourse,course) => new EnrollCourseDto
                    {
                        CourseName = course.Name,
                        Author= course.Author,
                        Language = course.Language,
                        Hours = course.Hours,
                        Created = course.CreatedDate.ToString(),
                        Rating = course.Rating,
                        Tag  = course.Tag
                    }).ToListAsync();
                return data.AsReadOnly();
            }
        }
    }
}
