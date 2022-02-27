using Bitci.Portfolio.Application.Common.Repositories;
using Bitci.Portfolio.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Bitci.Portfolio.Infrastructure.Repositories
{
    public class CoinRepository : ICoinRepository
    {
        private readonly PortfolioDbContext _context;
        public CoinRepository(PortfolioDbContext context)
        {
            _context = context;
        }
        public async Task Add(Bitci.Portfolio.Domain.Entities.Coin coin)
        {
            _context.Coins.Add(coin);
            await _context.SaveChangesAsync();
        }

        public async Task<Bitci.Portfolio.Domain.Entities.Coin[]> GetCoinsByUserId(string userId)
        {
           return await _context.Coins.Where(x => x.UserId == userId).ToArrayAsync();
        }
    }
}
