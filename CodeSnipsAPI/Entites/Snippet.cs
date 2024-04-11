using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeSnipsAPI.Entites
{
    public class Snippet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string Code { get; set; }

        public Snippet(string language, string code) 
        {
            Language = language;
            Code = code;
        }
    }
}
