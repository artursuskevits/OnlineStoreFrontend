using System;
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

        // Получение корзины пользователя
        public async Task<Cart> GetCart(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"carts/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Cart>();
                }
                else
                {
                    Console.WriteLine($"Error fetching cart: {response.StatusCode} - {response.ReasonPhrase}");
                    throw new Exception($"Error fetching cart: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred while fetching cart: {ex.Message}");
                throw;
            }
        }

        // Добавление товара в корзину
        public async Task AddToCart(int userId, int productId, int quantity)
        {
            try
            {
                var cartItemDto = new { ProductId = productId, Quantity = quantity };
                var response = await _httpClient.PostAsJsonAsync($"carts/{userId}/add", cartItemDto);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error adding product to cart: {response.StatusCode} - {response.ReasonPhrase}");
                    throw new Exception($"Error adding product to cart: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred while adding to cart: {ex.Message}");
                throw;
            }
        }

        // Удаление товара из корзины
        public async Task RemoveFromCart(int userId, int productId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"carts/{userId}/remove?productId={productId}");
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error removing product from cart: {response.StatusCode} - {response.ReasonPhrase}");
                    throw new Exception($"Error removing product from cart: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred while removing from cart: {ex.Message}");
                throw;
            }
        }

        // Оформление заказа
        public async Task<HttpResponseMessage> Checkout(int userId)
        {
            try
            {
                var response = await _httpClient.PostAsync($"carts/{userId}/checkout", null);
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Error during checkout: {response.StatusCode} - {response.ReasonPhrase}");
                    throw new Exception($"Error during checkout: {response.ReasonPhrase}");
                }
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred during checkout: {ex.Message}");
                throw;
            }
        }
    }
}
