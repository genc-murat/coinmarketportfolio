using Bitci.Portfolio.Application.Common.DTOs;
using Bitci.Portfolio.Application.Listing.Queries.GetListings;

namespace Bitci.Portfolio.UI.Services
{
    public interface IPortfolioService
    {
        Task<ListingItemDto[]> Getlistings();
        Task<CoinDto[]> GetCoins();
        Task AddCoin(CoinDto coin);
    }
}
