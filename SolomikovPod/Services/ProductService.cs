using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using SolomikovPod.Models;

namespace SolomikovPod.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProducts()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Product>>("products");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching products: {ex.Message}");
                return new List<Product>();
            }
        }


        public async Task<Product> GetProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"products/{id}");
        }

        public async Task AddToCart(int userId, int productId, int quantity = 1)
        {
            await _httpClient.PostAsJsonAsync($"Carts/{userId}/add", new { productId, quantity });
        }
    }
}
