using MediatR;

namespace Bitci.Portfolio.Application.Coin.Commands.AddCoin
{
    public class AddCoinCommand : IRequest<bool>
    {
     
        public string UserId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
