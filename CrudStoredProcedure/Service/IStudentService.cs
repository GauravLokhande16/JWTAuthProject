using CrudStoredProcedure.Models;

namespace CrudStoredProcedure.Service
{
    public interface IStudentService
    {
        List<Student> GetStudents(string Name);
        void SaveOrUpdate(Student student);
        void Delete(int StudentId);
    }
}
