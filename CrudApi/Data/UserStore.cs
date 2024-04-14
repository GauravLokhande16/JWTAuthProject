using CrudApi.Models;
using CrudApi.Models.Dto;

namespace CrudApi.Data
{
    public static class UserStore
    {
        public static List<UserDto> userList = new List<UserDto>
        {
            new UserDto{Id=1,Email="gaurav@gamil.com",Name="Guarav"},
            new UserDto{Id=2,Email="akshay@gmail.com",Name="Akshay"}
        };
    }
}
