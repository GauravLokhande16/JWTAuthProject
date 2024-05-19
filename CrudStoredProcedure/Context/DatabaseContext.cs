using CrudStoredProcedure.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudStoredProcedure.Context
{
    public class DatabaseContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = string.Format(@"Data Source=DESKTOP-MEDAAKL\MSSQLSERVER01;Initial Catalog=SchoolDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            options.UseSqlServer(connectionString);
        }
        public DbSet<Student> Students { get; set; } 
    }
}
