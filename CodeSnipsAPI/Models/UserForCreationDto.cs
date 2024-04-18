using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CodeSnipsAPI.Models
{
    public class UserForCreationDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
