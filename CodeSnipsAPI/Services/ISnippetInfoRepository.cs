using CodeSnipsAPI.Entites;

namespace CodeSnipsAPI.Services
{
    public class ISnippetInfoRepository
    {
        Task<IEnumerable<Snippet>> GetSnippetsAsync();
        Task<Snippet?> GetSnippetAsync(int snippetId);
    }
}
