using AdminAndInstructor.Microservice.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminAndInstructor.Microservice.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Course> Course { get; set;}
        public DbSet<Content> Content { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
