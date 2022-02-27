using Bitci.Portfolio.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Bitci.Portfolio.Infrastructure.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual IList<Coin> Coins { get; set; }
    }
}
