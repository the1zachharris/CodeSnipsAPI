using Microsoft.EntityFrameworkCore;
using CodeSnipsAPI.DbContexts;
using CodeSnipsAPI.Entites;

namespace CodeSnipsAPI.Services
{
    public class SnippetInfoRepository : ISnippetInfoRepository
    {
        private UserInfoContext _context;

        public SnippetInfoRepository(UserInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Snippet>> GetSnippetsAsync()
        {
            return await _context.Snippets.ToListAsync();
        }

        public async Task<Snippet?> GetSnippetAsync(int snippetId)
        {
            return await _context.Snippets.Where(c => c.Id == snippetId).FirstOrDefaultAsync();
        }
    }
}
