using Bitci.Portfolio.Application.Common.DTOs;
using Bitci.Portfolio.Application.Listing.Queries.GetListings;
using Blazored.LocalStorage;
using System.Text;
using System.Text.Json;

namespace Bitci.Portfolio.UI.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        public PortfolioService(HttpClient httpClient, ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task AddCoin(CoinDto coin)
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            string userId = await _localStorage.GetItemAsync<string>("userId");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            coin.UserId = userId;
            var content = new StringContent(JsonSerializer.Serialize(coin),Encoding.UTF8,"application/json");
             await _httpClient.PostAsync($"/api/coin",content);

        }

        public async Task<CoinDto[]> GetCoins()
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            string userId = await _localStorage.GetItemAsync<string>("userId");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"/api/coin/{userId}");
            var json = await response.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<CoinDto[]>(json);
        }

        public async Task<ListingItemDto[]> Getlistings()
        {
            string token = await _localStorage.GetItemAsync<string>("authToken");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("/api/listing");
            var json = await response.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<ListingItemDto[]>(json);

        }


    }
}
