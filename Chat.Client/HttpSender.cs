using Chat.Shared;

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
        return await _httpClient.SendAsync(new HttpRequestMessage(method, uri));
    }
}