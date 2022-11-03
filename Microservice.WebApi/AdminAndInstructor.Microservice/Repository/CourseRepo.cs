using AdminAndInstructor.Microservice.Data;
using AdminAndInstructor.Microservice.Dto;
using AdminAndInstructor.Microservice.Models;
using ApiCommonLibrary;
using System.Threading.Tasks;
using EFCore.BulkExtensions;

namespace AdminAndInstructor.Microservice.Repository
{
    public interface ICourseRepo
    {
        public Task<ServiceResponse<dynamic>> AddCourse(AddCourseDto[] courseDto);
    }
    public class CourseRepo : ICourseRepo
    {
        DataContext dataContext { get; set; }
        public CourseRepo(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        public async Task<ServiceResponse<dynamic>> AddCourse(AddCourseDto[] courseDto)
        {
            dynamic course;
            foreach (var element in courseDto)
            {
                course = new Course()
                {
                    Name = element.CourseName,
                    Tag = element.Tag,
                    Rating = element.Ratings,
                    Author = element.Author,
                    Language = element.Language,
                    Hours = element.Hours,
                };
                course.Categories = new Category()
                {
                    CategoryName = element.Category,
                    SubCategory = element.SubCategory,
                    Topics = new Topic()
                    {
                        TopicName = element.TopicName,
                    }
                };
                course.Contents = new Content()
                {
                    ContentName = element.Content,
                };
            }
           
            //await dataContext.BulkInsertAsync(data);



            //await dataContext.Course.AddAsync(new Models.Course
            //{
            //    Name = courseDto.CourseName,
            //    Tag = courseDto.Tag,
            //    Rating = courseDto.Ratings,
            //    Author = courseDto.Author,
            //    Language = courseDto.Language,
            //    Hours = courseDto.Hours,

            //});

            return new ServiceResponse<dynamic> { Data = 1 };

        }
    }
}
