using CodeSnipsAPI.Entites;

namespace CodeSnipsAPI.Services
{
    public interface ISnippetInfoRepository
    {
        Task<IEnumerable<Snippet>> GetSnippetsAsync();
        Task<Snippet?> GetSnippetAsync(int snippetId);
    }
}
