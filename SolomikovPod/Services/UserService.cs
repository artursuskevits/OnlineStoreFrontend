using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SolomikovPod.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Register(User user)
        {
            await _httpClient.PostAsJsonAsync("Users/register", user);
        }

        public async Task<User> Login(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("Users/login", new { username, password });
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<User>() : null;
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
    }
}
