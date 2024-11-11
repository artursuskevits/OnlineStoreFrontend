using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        public async Task AddProduct(Product product)
        {
            await _httpClient.PostAsJsonAsync("Products", product);
        }

        public async Task UpdateProduct(int id, Product product)
        {
            await _httpClient.PutAsJsonAsync($"Products/{id}", product);
        }

        public async Task DeleteProduct(int id)
        {
            await _httpClient.DeleteAsync($"Products/{id}");
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Currency { get; set; }
    }
}
