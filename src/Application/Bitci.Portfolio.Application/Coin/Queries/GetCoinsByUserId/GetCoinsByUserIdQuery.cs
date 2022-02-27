using Bitci.Portfolio.Application.Common.DTOs;
using MediatR;

namespace Bitci.Portfolio.Application.Coin.Queries.GetCoinsByUserId
{
    public class GetCoinsByUserIdQuery : IRequest<CoinDto[]>
    {
        public string UserId { get; set; }
    }
}
