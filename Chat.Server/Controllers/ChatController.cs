using System.Collections;
using Chat.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Chat.Server.Controllers
{
    [ApiController]
    [Route("chat")]
    public class ChatController : ControllerBase
    {
        private readonly MessagesRepository _repository;

        public ChatController(MessagesRepository repository)
        {
            _repository = new MessagesRepository(new List<Message>
            {
                new ("Аркадий", "Всем привет"),
                new ("Вася", "Привет"),
                new ("Петя", "И вам привет"),
            });
        }

        [HttpGet]
        public ActionResult<IList<Message>> GetAllMessages()
        {
            try
            {
                return _repository.Messages;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Array.Empty<Message>();
            }
        }
    }
}