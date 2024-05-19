using CrudStoredProcedure.Context;
using CrudStoredProcedure.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudStoredProcedure.Service
{
    public class StudentService : IStudentService
    {
        DatabaseContext _dbContext = null;
        public StudentService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Delete(int StudentId)
        {
            _dbContext.Database.ExecuteSqlRaw($"DeleteStudent {StudentId}");
        }

        public List<Student> GetStudents(string name)
        {
            var students = _dbContext.Students.FromSqlRaw($"GetStudents {name}").ToList();
            return students;
        }

        public void SaveOrUpdate(Student student)
        {
            _dbContext.Database.ExecuteSqlRaw($"SaverOrUpdateStudent {student.StudentId}, {student.StudentName}, {student.Age}");

            var students = _dbContext.Students.ToList();
        }
    }
}
