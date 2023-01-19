using Microsoft.AspNetCore.Mvc;

namespace Chat.Server.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        UserRepository _userRepository;
        public AuthController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public ActionResult Logout([FromBody] string user)
        {
            _userRepository.Login(user);
            return Ok();
        }

        [HttpPost("logout")]
        public ActionResult Login([FromBody] string user)
        {
            _userRepository.Login(user);
            return Ok();
        }
    }
}
