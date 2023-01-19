using Chat.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Server.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        UserRepository _userRepository;
        public LoginController(UserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }    

        [HttpPost]
        public ActionResult Login([FromBody] string user)
        {
            _userRepository.Login(user);
            return Ok();
        }
    }
}
