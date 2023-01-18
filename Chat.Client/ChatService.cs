using System.Net.Http.Json;
using Message = Chat.Shared.Message;

namespace Chat.Client;

public static class ChatService
{
    public static async Task<List<Message>?> GetAllMessages()
    {
        var response = await HttpSender.SendAsync(HttpMethod.Get, "chat");
        return await response.Content.ReadFromJsonAsync<List<Message>>();
    }

    public static async Task AddMessage(string sender, string text)
    {
        Message message = new Message(sender, text);
        var response = await HttpSender.SendAsync(HttpMethod.Post, "chat", message);
    }
}