using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            var cartItemDto = new { ProductId = productId, Quantity = quantity };
            // Fix the URL here to remove any extra 'api/' prefix
            await _httpClient.PostAsJsonAsync($"carts/{userId}/add", cartItemDto);
        }


        public async Task RemoveFromCart(int userId, int productId)
        {
            await _httpClient.DeleteAsync($"carts/{userId}/remove?productId={productId}");
        }
        public async Task Checkout(int userId)
        {
            await _httpClient.PostAsJsonAsync($"Payment/{userId}/checkout", new { });
        }

    }
}
