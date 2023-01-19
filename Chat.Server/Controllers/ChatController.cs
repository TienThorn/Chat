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
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Message>> GetAllMessages()
        {
            try
            {
                return _repository.Messages;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<Message>();
            }
        }

        [HttpPost]
        public ActionResult AddMessage([FromBody] Message message)
        {
            _repository.AddMessage(message);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteMessage([FromBody] int id)
        {
            _repository.DeleteMessage(id);
            return Ok();
        }

        [HttpPut]
        public ActionResult ChangeMessage([FromBody] Message message)
        {
            //_repository.AddMessage(id);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Message> GetMessageById(int id)
        {
            return _repository.GetMessageById(id);
        }

    }
}