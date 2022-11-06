using AdminAndInstructor.Microservice.Models;
using Microsoft.EntityFrameworkCore;
namespace AdminAndInstructor.Microservice.Data
{
    public class DataContext:DbContext
    {
        public DbSet<ApiCommonLibrary.DTO.Course> Course { get; set;}
        public DbSet<ApiCommonLibrary.DTO.Content> Content { get; set; }
        public DbSet<ApiCommonLibrary.DTO.Category> Category { get; set; }
        public DbSet<ApiCommonLibrary.DTO.Topic> Topic { get; set; }
        public DbSet<ApiCommonLibrary.DTO.EStudent> Students { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
