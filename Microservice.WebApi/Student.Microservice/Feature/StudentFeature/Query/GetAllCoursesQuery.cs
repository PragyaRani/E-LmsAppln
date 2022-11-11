using MediatR;
using System;
using System.Collections.Generic;
using ApiCommonLibrary.DTO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Student.Microservice.Data;
using Microsoft.EntityFrameworkCore;

namespace Student.Microservice.Feature.StudentFeature.Query
{
    public class GetAllCoursesQuery : IRequest<IEnumerable<Course>>
    {
        public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<Course>>
        {
            public readonly DataContext context;
            public GetAllCoursesQueryHandler(DataContext _context)
            {
                context = _context;
            }
            public async Task<IEnumerable<Course>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
            {
               
                var courseList = await context.Course.Include(c => c.Categories).Include(c => c.Contents)
                    .ToListAsync();
                if(courseList == null)
                {
                    return null;
                }
                return courseList.AsReadOnly();
            }
        }
    }
}
