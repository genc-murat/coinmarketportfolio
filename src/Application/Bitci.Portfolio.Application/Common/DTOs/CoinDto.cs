using Bitci.Portfolio.Application.Common.Mappings;
using System.Text.Json.Serialization;

namespace Bitci.Portfolio.Application.Common.DTOs
{
    public class CoinDto : IMapFrom<Bitci.Portfolio.Domain.Entities.Coin>
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("userId")]
        public string UserId { get; set; }
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("purchasePrice")]
        public decimal PurchasePrice { get; set; }
        [JsonPropertyName("quantity")]
        public decimal Quantity { get; set; }
        [JsonPropertyName("purchaseDate")]
        public DateTime PurchaseDate { get; set; }
    }
}
