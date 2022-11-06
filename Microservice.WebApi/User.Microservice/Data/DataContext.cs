using Microsoft.EntityFrameworkCore;
using User.Microservice.Models;
using ApiCommonLibrary.DTO;

namespace User.Microservice.Data
{
    public class DataContext:DbContext
    {
        public DbSet<EStudent> Students { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AddUser>().Property(e => e.UserId).ValueGeneratedOnAdd();
        }
    }
}
