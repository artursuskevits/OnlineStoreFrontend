using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using SolomikovPod.Models;

namespace SolomikovPod.Services
{
    public class CartService
    {
        private readonly HttpClient _httpClient;

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Cart> GetCart(int userId)
        {
            return await _httpClient.GetFromJsonAsync<Cart>($"Carts/{userId}");
        }

        public async Task AddToCart(int userId, int productId, int quantity)
        {
            await _httpClient.PostAsJsonAsync($"Carts/{userId}/add", new { productId, quantity });
        }
        public async Task RemoveFromCart(int userId, int productId)
        {
            await _httpClient.DeleteAsync($"Carts/{userId}/remove/{productId}");
        }


    }
}
