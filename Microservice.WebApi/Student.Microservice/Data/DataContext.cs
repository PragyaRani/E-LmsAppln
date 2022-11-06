using ApiCommonLibrary.DTO;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Student.Microservice.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Course> Course { get; set; }
        public DbSet<EStudent> Students { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DataContext(DbContextOptions<DataContext> options):base(options) { }


        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
