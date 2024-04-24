
using AutoMapper;
using CodeSnipsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnipsAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserDto>> GetUser(int id)
        //{

        //}
    }
}
