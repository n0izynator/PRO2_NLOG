using System.Threading.Tasks;
using Library.Models.DTO;
using Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            _logger.LogError("Wystąpił błąd w GetUsers");

            var res = await _userRepository.GetUsers();
            return Ok(res);
        }

        [HttpPost(Name = nameof(AddUser))]
        public async Task<IActionResult> AddUser([FromBody] UserDto user)
        {
           var res = await _userRepository.AddUser(user);

            return CreatedAtRoute(nameof(AddUser), res);
        }

        [HttpGet("{idUser:int}")]
        public async Task<IActionResult> GetUser([FromRoute] int idUser)
        {
            var res = await _userRepository.GetUser(idUser);
            return Ok(res);
        }
        
    }
}