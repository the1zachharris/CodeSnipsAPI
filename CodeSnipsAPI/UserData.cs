using CodeSnipsAPI.Models;

namespace CodeSnipsAPI
{
    public class UserData
    {
        public List<UserDto> User { get; set; }
        public static UserData Current { get; } = new UserData();
        public UserData() 
        {
            User = new List<UserDto>()
            {
                new UserDto()
                {
                    Id = 1,
                    Email = "test1@email.com",
                    Password = "password",
                },
                new UserDto()
                {
                    Id = 1,
                    Email = "test2@email.com",
                    Password = "password",
                }
            };
        }
    }
}
