using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SolomikovPod.Models;

namespace SolomikovPod.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> Register(User user)
        {
            var response = await _httpClient.PostAsJsonAsync("Users/register", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<User>();
        }

        public async Task<User> Login(LoginRequest loginRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("Users/login", loginRequest);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<User>();
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
