using AutoMapper;
using CodeSnipsAPI.Models;
using CodeSnipsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnipsAPI.Controllers
{
    [Route("api/snippet")]
    [ApiController]

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
        public async Task<ActionResult<IEnumerable<SnippetDto>>> GetSnippets()
        {
            var snipsEntities = await _snippetInfoRepository.GetSnippetsAsync();
            return Ok(_mapper.Map<IEnumerable<SnippetDto>>(snipsEntities));
        }
    }
}
