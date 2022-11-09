using Microsoft.EntityFrameworkCore;
using ApiCommonLibrary.DTO;
namespace AdminAndInstructor.Microservice.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Course> Course { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<EStudent> Students { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>().Property(e => e.CreatedDate).
                HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Notification>().Property(e => e.EnrollDate).
                HasDefaultValueSql("getdate()");
        }
    }
}
