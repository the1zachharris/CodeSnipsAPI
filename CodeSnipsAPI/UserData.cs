using CodeSnipsAPI.Models;

namespace CodeSnipsAPI
{
    public class UserData
    {
        public List<User> User { get; set; }
        public static UserData Current { get; } = new UserData();
        public UserData() 
        {
            User = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Email = "test1@email.com",
                    Password = "password",
                },
                new User()
                {
                    Id = 1,
                    Email = "test2@email.com",
                    Password = "password",
                }
            };
        }
    }
}
