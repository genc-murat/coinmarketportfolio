using Bitci.Portfolio.Application.Common.Interfaces;
using MediatR;

namespace Bitci.Portfolio.Application.Coin.Commands.AddCoin
{
    public class AddCoinCommandHandler : IRequestHandler<AddCoinCommand, bool>
    {
        private readonly ICoinService _coinService;
        public AddCoinCommandHandler(ICoinService coinService)
        {
            _coinService = coinService;
        }
        public async Task<bool> Handle(AddCoinCommand request, CancellationToken cancellationToken)
        {
            await _coinService.Add(new Common.DTOs.CoinDto { Name = request.Name, PurchaseDate = request.PurchaseDate, PurchasePrice = request.PurchasePrice, Quantity = request.Quantity, Symbol = request.Symbol, UserId = request.UserId });

            return true;
        }
    }
}
