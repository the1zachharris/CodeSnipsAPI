using AutoMapper;
using CodeSnipsAPI.Models;
using CodeSnipsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnipsAPI.Controllers
{
    [ApiController]
    [Route("api/snippet")]

    public class SnippetController : ControllerBase
    {
        private readonly ISnippetInfoRepository _snippetInfoRepository;
        private readonly IMapper _mapper;

        public SnippetController(ISnippetInfoRepository snippetInfoRepository, IMapper mapper) 
        {
            _snippetInfoRepository = snippetInfoRepository ?? throw new ArgumentNullException(nameof(snippetInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IEnumerable<SnippetDto>> GetSnippets()
        {
            var snips = await _snippetInfoRepository.GetSnippetsAsync();
            return Ok(_mapper.Map<IEnumerable<SnippetDto>>(snips));
        }
    }
}
