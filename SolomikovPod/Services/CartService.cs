using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SolomikovPod.Services
{
    public class CartService
    {
        private readonly HttpClient _httpClient;

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddToCart(int userId, int productId, int quantity)
        {
            await _httpClient.PostAsJsonAsync($"Carts/{userId}/add", new { productId, quantity });
        }

        public async Task<Cart> GetCart(int userId)
        {
            return await _httpClient.GetFromJsonAsync<Cart>($"Carts/{userId}");
        }
    }

    public class Cart
    {
        public int Id { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
