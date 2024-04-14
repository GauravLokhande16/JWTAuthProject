using NewCrudApi.Models.Dto;

namespace NewCrudApi.Data
{
    public static class UsersData
    {
        public static List<UserDto> userList = new List<UserDto>
            {
                new UserDto{Id=1,Name="Gaurav",Designation="PAT"},
                new UserDto{Id=2,Name="Rucha",Designation="PA"}
            };
    }
}
