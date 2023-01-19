using System.Linq;
using Chat.Shared;

namespace Chat.Server;

public class MessagesRepository
{
    public MessagesRepository()
    {
        
    } 

    public MessagesRepository(IEnumerable<Message> messages)
    {
        Messages = messages.ToList();
    }

    public List<Message> Messages { get; } = new();

    public void AddMessage(Message message)
    {
        Messages.Add(message);
    }

    public void DeleteMessage(int id)
    {
        Messages.RemoveAll(x => x.Id == id);
    }

    public void ChangeMessage(int id)
    {

    }

    public Message GetMessageById(int id)
    {
        foreach (Message message in Messages)
        {
            if (message.Id == id) 
            { 
                return message;
            }
        }
        return null;
    }
}