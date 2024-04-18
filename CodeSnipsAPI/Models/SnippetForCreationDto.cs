using System.ComponentModel.DataAnnotations;

namespace CodeSnipsAPI.Models
{
    public class SnippetForCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string Language { get; set; } = string.Empty;
        [Required]
        public string Code { get; set; } = string.Empty;
    }
}
