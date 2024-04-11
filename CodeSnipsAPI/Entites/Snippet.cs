using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSnipsAPI.Entites
{
    public class Snippet(string language, string code)
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Language { get; set; } = language;
        [Required]
        public string Code { get; set; } = code;
    }
}
