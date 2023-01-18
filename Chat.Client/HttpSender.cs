using Chat.Shared;
using System.Text.Json.Nodes;

namespace Chat.Client;

public class HttpSender
{
    private static HttpClient _httpClient;

    static HttpSender()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(Consts.BackendUrl);
    }

    public static async Task<HttpResponseMessage> SendAsync(HttpMethod method, string uri)
    {
        HttpRequestMessage requestMessage = new HttpRequestMessage(method, uri);
        return await _httpClient.SendAsync(requestMessage);
    }

    public static async Task<HttpResponseMessage> SendAsync(HttpMethod method, string uri, object body)
    {
        HttpRequestMessage requestMessage = new HttpRequestMessage(method, uri);
        requestMessage.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(body), System.Text.Encoding.UTF8, "application/json");
        return await _httpClient.SendAsync(requestMessage);
    }
}