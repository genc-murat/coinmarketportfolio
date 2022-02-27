namespace Bitci.Portfolio.Application.Common.Repositories
{
    public interface ICoinRepository
    {
        Task Add(Bitci.Portfolio.Domain.Entities.Coin coin);
        Task<Bitci.Portfolio.Domain.Entities.Coin[]> GetCoinsByUserId(string userId);
    }
}
