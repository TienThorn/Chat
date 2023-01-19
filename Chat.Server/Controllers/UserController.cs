using Chat.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Server.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : Controller
    {
        UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public ActionResult<List<string>> GetOnlineUsers()
        {
            return _userRepository.Users.ToList();
        }
    }
}
