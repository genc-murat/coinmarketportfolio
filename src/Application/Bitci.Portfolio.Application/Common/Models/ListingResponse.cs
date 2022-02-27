using System.Text.Json.Serialization;

namespace Bitci.Portfolio.Application.Common.Models
{
    public class ListingResponse
    {
        [JsonPropertyName("data")]
        public ListingResponseItem[] Data { get; set; }
    }

    public class ListingResponseItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        [JsonPropertyName("quote")]
        public ListingQuoteResponse Quote { get; set; } = new ListingQuoteResponse();
    }

    public class ListingQuoteResponse
    {
        [JsonPropertyName("USD")]
        public ListingQuoteUSDResponse USD { get; set; } = new ListingQuoteUSDResponse();
    }

    public class ListingQuoteUSDResponse
    {
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("percent_change_24h")]
        public decimal PercentChange24h { get; set; }

    }
}
