using CrudStoredProcedure.Models;
using CrudStoredProcedure.Service;
using Microsoft.AspNetCore.Mvc;

namespace CrudStoredProcedure.Controllers
{
    public class StudentsController : Controller
    {
        IStudentService _studentService = null;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public List<Student> GetStudents(string name)
        {
            return _studentService.GetStudents(name);
        }
        public void SaveOrUpdate(Student student)
        {
            _studentService.SaveOrUpdate(student);
        }
        public void Delete(int studentId)
        {
            _studentService.Delete(studentId);
        }
    }
}
