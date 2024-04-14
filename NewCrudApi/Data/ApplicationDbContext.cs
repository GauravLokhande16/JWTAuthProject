using Microsoft.EntityFrameworkCore;
using NewCrudApi.Models;

namespace NewCrudApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<UsersModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersModel>().HasData(
                new UsersModel() { Id = 1, Name = "Test1", Designation="PA",CreatedDate=DateTime.Now },
                new UsersModel() { Id = 2, Name = "Test2", Designation="PAT",CreatedDate = DateTime.Now }
            );
        }
    }
}
