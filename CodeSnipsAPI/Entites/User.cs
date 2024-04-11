using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSnipsAPI.Entites
{
    public class User(string email, string password)
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; } = email;
        [Required]
        public string Password { get; set; } = password;
    }
}
