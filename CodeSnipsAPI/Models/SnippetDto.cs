namespace CodeSnipsAPI.Models
{
    public class SnippetDto
    {
        public int Id { get; set; }
        public string Language { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
