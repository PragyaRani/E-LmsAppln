using AdminAndInstructor.Microservice.Data;
using AdminAndInstructor.Microservice.Dto;
using ApiCommonLibrary;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using ApiCommonLibrary.Models;
using ApiCommonLibrary.DTO;
using System.Collections;

namespace AdminAndInstructor.Microservice.Repository
{
    public interface ICourseRepo
    {
        public Task<ServiceResponse<dynamic>> AddCourse(AddCourseDto[] courseDto);
        public Task<ServiceResponse<dynamic>> UpdateCourse(int id,UpdateCourseDto courseDto);
        public Task<object> GetCoursebyId(int id);
        public Task AddNotification(EnrollCourseModel enrollCourseModel);
        public Task<IList> GetNotification();

        public Task<ServiceResponse<dynamic>> GetEnrollStudents();


    }
    public class CourseRepo : ICourseRepo
    {
        DataContext dataContext { get; set; }
        public CourseRepo(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        public async Task<ServiceResponse<dynamic>> GetEnrollStudents()
        {
            try
            {
                var enrollStudents = await dataContext.StudentCourse.Join(dataContext.Students, sc => sc.EStudent.StudentId,
                stu => stu.StudentId, (sc, stu) => new { sc, stu }).
                Join(dataContext.Course, stuc => stuc.sc.Course.CourseId, crs => crs.CourseId, (stuc, crs) => new
                {
                    name = stuc.stu.Name,
                    email = stuc.stu.Email,
                    courseName = crs.Name,
                    author = crs.Author
                }).ToListAsync();
                if (enrollStudents == null)
                {
                    return new ServiceResponse<dynamic>
                    {
                        Message = "No Students have been enrolled yet"
                    };
                }
                return new ServiceResponse<dynamic>
                {
                    Data = enrollStudents
                };
            }
            catch(Exception ex)
            {
                return new ServiceResponse<dynamic>
                {
                    Message = ex.Message
                };
            }
        }
        public async Task<object> GetCoursebyId(int id)
        {
            try 
            {
                Course data = await dataContext.Course.Where(c => c.CourseId == id).Include(c => c.Categories).
                             Include(c=> c.Contents).Include(c => c.Topics).
                             FirstOrDefaultAsync();
                return data;
            } catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<ServiceResponse<dynamic>> AddCourse(AddCourseDto[] courseDto)
        {
            List<Course> course = new List<Course>();
            foreach (var element in courseDto)
            {
                var categoryInfo = await dataContext.Category.
                            Where(c => c.CategoryName == element.Category && 
                            c.SubCategory == element.SubCategory).SingleOrDefaultAsync();
                if(categoryInfo == null)
                {
                    return new ServiceResponse<dynamic> 
                        { Success = false, Message ="Category not exist" };
                }
                var topicInfo= await dataContext.Topic.
                          Where(c => c.TopicName == element.TopicName).SingleOrDefaultAsync();

                if(topicInfo == null)
                    return new ServiceResponse<dynamic>
                        { Success = false, Message = "Topic not exist" };

                var contentInfo = await dataContext.Content.
                          Where(c => c.ContentName == element.Content).SingleOrDefaultAsync();
                if(contentInfo == null)
                    return new ServiceResponse<dynamic>
                        { Success = false, Message = "Content not exist" };

                course.Add(new Course()
                {
                    Name = element.CourseName,
                    Tag = element.Tag,
                    Rating = element.Ratings,
                    Author = element.Author,
                    Language = element.Language,
                    Hours = element.Hours,
                    Categories = new Category()
                    {
                        Id = categoryInfo.Id,
                    },
                    Contents = contentInfo,
                    Topics = topicInfo,
                });
            }

            await dataContext.BulkInsertAsync(course);
            return new ServiceResponse<dynamic> { Data = course };

        }

        public async Task<ServiceResponse<dynamic>> UpdateCourse(int id,UpdateCourseDto updateCourseDto)
        {
            try 
            {
                Course course = await dataContext.Course.FirstOrDefaultAsync(c => c.CourseId == id);
                if (course == null)
                {
                    return new ServiceResponse<dynamic>
                    {
                        Success = false,
                        Message = "Course not exist"
                    };

                }
                course.Name = updateCourseDto.CourseName;
                course.Tag = updateCourseDto.Tag;
                course.Categories = new Category
                {
                    CategoryName = updateCourseDto.Category,
                    SubCategory = updateCourseDto.SubCategory
                };
                course.Hours = updateCourseDto.Hours;
                course.Rating = updateCourseDto.Ratings;
                dataContext.Update(course);
                await dataContext.SaveChangesAsync();
                return new ServiceResponse<dynamic>()
                {
                    Message = "Course has been updated successfully"
                };
            } catch(Exception ex){
                return new ServiceResponse<dynamic>()
                {
                    Success = false,
                    Message = "Something Wrong with Server"
                };
            }
            
        }

        public async Task AddNotification(EnrollCourseModel enrollCourseModel)
        {
            try
            {
                dataContext.Notification.Add(new Notification
                { Name = $"{enrollCourseModel.Student} enrolled for course {enrollCourseModel.Course}" });
                await dataContext.SaveChangesAsync();
            } catch(Exception ex)
            {
                new ServiceResponse<dynamic>()
                {
                    Success = false,
                    Message = "Something Wrong with Server"
                };
            }
          
        }
        public async Task<IList> GetNotification()
        {
            try
            {
                return await dataContext.Notification.OrderByDescending(n => n.EnrollDate).ToListAsync();
            }
            catch(Exception ex){
                return null;
            }
           
        }
    }
}
