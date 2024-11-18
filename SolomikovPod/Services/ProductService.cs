using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
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
            return await _httpClient.GetFromJsonAsync<List<Product>>("Products");
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"Products/{id}");
        }

        public async Task AddToCart(int userId, int productId)
        {
            var response = await _httpClient.PostAsync($"Carts/{userId}/add?productId={productId}&quantity=1", null);
            response.EnsureSuccessStatusCode();
        }

    }
}
