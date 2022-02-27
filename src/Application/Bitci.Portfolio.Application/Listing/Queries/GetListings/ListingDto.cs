using Bitci.Portfolio.Application.Common.Mappings;
using Bitci.Portfolio.Application.Common.Models;
using System.Text.Json.Serialization;

namespace Bitci.Portfolio.Application.Listing.Queries.GetListings
{
    public class ListingDto: IMapFrom<ListingResponse>
    {
        [JsonPropertyName("data")]
        public ListingItemDto[] Data { get; set; }
    }

    public class ListingItemDto : IMapFrom<ListingResponseItem>
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = string.Empty;
        [JsonPropertyName("quote")]
        public ListingQuoteDto Quote { get; set; } = new ListingQuoteDto();
    }

    public class ListingQuoteDto : IMapFrom<ListingQuoteResponse>
    {
        [JsonPropertyName("USD")]
        public ListingQuoteUSDDto USD { get; set; } = new ListingQuoteUSDDto();
    }

    public class ListingQuoteUSDDto : IMapFrom<ListingQuoteUSDResponse>
    {
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("percent_change_24h")]
        public decimal PercentChange24h { get; set; }
    }
}
