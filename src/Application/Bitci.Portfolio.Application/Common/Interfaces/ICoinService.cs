using Bitci.Portfolio.Application.Common.DTOs;

namespace Bitci.Portfolio.Application.Common.Interfaces
{
    public interface ICoinService
    {
        Task Add(CoinDto coin);
        Task<CoinDto[]> GetCoinsByUserId(string userId);
    }
}
