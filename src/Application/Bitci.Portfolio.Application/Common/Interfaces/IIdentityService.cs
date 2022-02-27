using Bitci.Portfolio.Application.Common.Models;

namespace Bitci.Portfolio.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<(ResultResponse Result, string Token)> LoginAsync(string email, string password);

    Task<(ResultResponse Result, string UserId)> CreateUserAsync(string name, string lastName, string email, string password);

  
}

