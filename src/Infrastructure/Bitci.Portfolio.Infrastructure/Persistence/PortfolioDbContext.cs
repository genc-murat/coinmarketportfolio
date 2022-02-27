
using Bitci.Portfolio.Domain.Entities;
using Bitci.Portfolio.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bitci.Portfolio.Infrastructure.Persistence
{
    public class PortfolioDbContext : IdentityDbContext<User>
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {
        }
        public DbSet<Coin> Coins { get; set; }
    }
}
