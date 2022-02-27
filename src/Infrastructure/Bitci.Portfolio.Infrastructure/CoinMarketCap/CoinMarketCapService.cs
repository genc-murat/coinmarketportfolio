using Bitci.Portfolio.Application.Common.Interfaces;
using Bitci.Portfolio.Application.Common.Models;

namespace Bitci.Portfolio.Infrastructure.CoinMarketCap
{
    public class CoinMarketCapService : ICoinMarketCapService
    {
        private readonly HttpClient _httpClient;
        public CoinMarketCapService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ListingResponse> ListingsAsync()
        {
            var responseMessage = await _httpClient.GetAsync("/v1/cryptocurrency/listings/latest?limit=10");
            if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK) return null;
            var data = await responseMessage.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<ListingResponse>(data);
        }
    }
}
