using System.Diagnostics;
using System.Net.Http.Json;
using System.Linq;
using Message = Chat.Shared.Message;

namespace Chat.Client;

public static class ChatService
{
    public static async Task<List<Message>?> GetAllMessages()
    {
        var response = await HttpSender.SendAsync(HttpMethod.Get, "chat");
        var result = await response.Content.ReadFromJsonAsync<List<Message>>();
        return result;
    }

    public static async Task SendMessage(string sender, string text)
    {
        switch (CheckForCommand(text))
        {
            case TypeMessage.Message:
                {
                    await AddMessage(sender, text);
                    break;
                }
            case TypeMessage.DeleteMessage:
                {
                    int id = Convert.ToInt32(text.Remove(0, 5));
                    await DeleteMessage(id);
                    break;
                }
            case TypeMessage.BanUser:
                {
                    await AddMessage(sender, text);
                    break;
                }
        }
    }

    private static async Task AddMessage(string sender, string text)
    {
        Message message = new Message(sender, text);
        var response = await HttpSender.SendAsync(HttpMethod.Post, "chat", message);
    }

    private static async Task DeleteMessage(int id)
    {
        var response = await HttpSender.SendAsync(HttpMethod.Delete, "chat", id);
    }

    private static async Task ChangeMessage(int id, string text)
    {
        var response = await HttpSender.SendAsync(HttpMethod.Get, "chat/" + id);
        Message message = await response.Content.ReadFromJsonAsync<Message>();
        var newResponse = await HttpSender.SendAsync(HttpMethod.Put, "chat", message);
    }

    private static TypeMessage CheckForCommand(string message)
    {
        if (message.StartsWith("/ban"))
        {
            return TypeMessage.BanUser;
        }
        else if (message.StartsWith("/del"))
        {
            return TypeMessage.DeleteMessage;
        }
        else if (message.StartsWith("/change"))
        {
            return TypeMessage.ChangeMessage;
        }
        else
        {
            return TypeMessage.Message;
        }
    }

    public enum TypeMessage
    {
        Message,
        DeleteMessage,
        ChangeMessage,
        BanUser,       
    }
}