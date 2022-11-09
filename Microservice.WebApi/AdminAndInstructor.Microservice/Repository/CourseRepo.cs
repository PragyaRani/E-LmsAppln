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
    }
    public class CourseRepo : ICourseRepo
    {
        DataContext dataContext { get; set; }
        public CourseRepo(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }
        public async Task<object> GetCoursebyId(int id)
        {
            return await dataContext.Course.Include(c => c.Categories).Include(c => c.Contents).
                Where(c => c.CourseId == id).FirstOrDefaultAsync();
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
                //course.Categories = new Category()
                //{
                //    CategoryName = element.Category,
                //    SubCategory = element.SubCategory,
                //    Topics = new Topic()
                //    {
                //        TopicName = element.TopicName,
                //    }
                //};
                //course.Contents = new Content()
                //{
                //    ContentName = element.Content,
                //};
            }

            await dataContext.BulkInsertAsync(course);
            return new ServiceResponse<dynamic> { Data = course };

        }

        public async Task<ServiceResponse<dynamic>> UpdateCourse(int id,UpdateCourseDto updateCourseDto)
        {
            ApiCommonLibrary.DTO.Course course =await dataContext.Course.FirstOrDefaultAsync(c => c.CourseId == id);
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
                course.Categories = new ApiCommonLibrary.DTO.Category
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
                    Message ="Course has been updated successfully"
                };
        }

        public async Task AddNotification(EnrollCourseModel enrollCourseModel)
        {
           dataContext.Notification.Add(new Notification
            { Name = $"{enrollCourseModel.Student} enrolled for course {enrollCourseModel.Course}" });
           await dataContext.SaveChangesAsync();
        }
        public async Task<IList> GetNotification()
        {
            return await dataContext.Notification.ToListAsync();
        }
    }
}
