using Bitci.Portfolio.Application.Common.DTOs;
using Bitci.Portfolio.Application.Common.Interfaces;
using MediatR;

namespace Bitci.Portfolio.Application.Coin.Queries.GetCoinsByUserId
{
    public class GetCoinsByUserIdQueryHandler : IRequestHandler<GetCoinsByUserIdQuery, CoinDto[]>
    {
        private readonly ICoinService _coinService;
   
        public GetCoinsByUserIdQueryHandler(ICoinService coinService)
        {
            _coinService = coinService;
        }
        public async Task<CoinDto[]> Handle(GetCoinsByUserIdQuery request, CancellationToken cancellationToken)
        {
           return await _coinService.GetCoinsByUserId(request.UserId);
        }
    }
}
