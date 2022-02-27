namespace Bitci.Portfolio.Application.Coin.Commands.AddCoin
{
    public class AddCoinDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Quantity { get; set; }
        public DateOnly PurchaseDate { get; set; }
    }
}
