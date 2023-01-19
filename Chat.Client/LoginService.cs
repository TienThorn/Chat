using System.Diagnostics;
using System.Net.Http.Json;
using System.Linq;

namespace Chat.Client
{
    public static class LoginService
    {
        public static async Task Login(string user)
        {
            var response = await HttpSender.SendAsync(HttpMethod.Post, "login", user);
        }

        public static async Task Logout(string user)
        {
            var response = await HttpSender.SendAsync(HttpMethod.Post, "logout", user);
        }
    }
}
