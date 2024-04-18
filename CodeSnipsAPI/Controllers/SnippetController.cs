using AutoMapper;
using CodeSnipsAPI.Models;
using CodeSnipsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using CodeSnipsAPI.Utilities;

namespace CodeSnipsAPI.Controllers
{
    [Route("api/snippet")]
    [ApiController]

    public class SnippetController : ControllerBase
    {
        private readonly ISnippetInfoRepository _snippetInfoRepository;
        private readonly IMapper _mapper;
        private readonly EncryptUtility _encryptUtility;

        public SnippetController(ISnippetInfoRepository snippetInfoRepository, IMapper mapper, EncryptUtility encryptUtility) 
        {
            _snippetInfoRepository = snippetInfoRepository ?? throw new ArgumentNullException(nameof(snippetInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _encryptUtility = encryptUtility ?? throw new ArgumentNullException(nameof(encryptUtility));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SnippetDto>>> GetSnippets()
        {
            var snipsEntities = await _snippetInfoRepository.GetSnippetsAsync();

            foreach (var snip in snipsEntities)
            {
                snip.Code = _encryptUtility.Decrypt(snip.Code);
            }

            return Ok(_mapper.Map<IEnumerable<SnippetDto>>(snipsEntities));
        }

        [HttpGet("{id}", Name = "getSnippet")]
        public async Task<IActionResult> GetSnippet(int id)
        {
            var snip = await _snippetInfoRepository.GetSnippetAsync(id);
            if (snip == null)
            {
                return NotFound();
            }
            snip.Code = _encryptUtility.Decrypt(snip.Code);
            return Ok(_mapper.Map<SnippetDto>(snip));
        }

        [HttpPost]
        public async Task<ActionResult<SnippetDto>> CreateSnippet(SnippetForCreationDto snip)
        {
            var finalSnip = _mapper.Map<Entites.Snippet>(snip);

            finalSnip.Code = _encryptUtility.Encrypt(finalSnip.Code);

            await _snippetInfoRepository.CreateSnippetAsync(finalSnip);
            await _snippetInfoRepository.SaveChangesAsync();

            var createdSnippetToReturn = _mapper.Map<Models.SnippetDto>(finalSnip);

            return CreatedAtRoute("getSnippet",
                new
                {
                    createdSnippetToReturn.Id
                },
                createdSnippetToReturn
            );
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteList(int id)
        {
            var snipEntity = await _snippetInfoRepository.GetSnippetAsync(id);
            if (snipEntity == null)
            {
                return NotFound();
            }
            _snippetInfoRepository.DeleteSnippet(snipEntity);
            await _snippetInfoRepository.SaveChangesAsync();
            return NoContent();
        }

    }
}
