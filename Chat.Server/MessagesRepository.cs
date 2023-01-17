using Chat.Shared;

namespace Chat.Server;

public class MessagesRepository
{
    public List<Message> Messages { get; } = new();

    public MessagesRepository()
    {
        
    }
    
    public MessagesRepository(IEnumerable<Message> messages)
    {
        Messages = messages.ToList();
    }
}