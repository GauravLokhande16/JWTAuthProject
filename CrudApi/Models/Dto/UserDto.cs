using System.ComponentModel.DataAnnotations;

namespace CrudApi.Models.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
