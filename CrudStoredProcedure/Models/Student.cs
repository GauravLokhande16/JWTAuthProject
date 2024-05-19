using System.ComponentModel.DataAnnotations;

namespace CrudStoredProcedure.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; } = 0;
        public string StudentName { get; set; } = "";
        public int Age { get; set; } = 0;
    }
}
