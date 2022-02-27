using Bitci.Portfolio.Application.Common.Interfaces;
using Bitci.Portfolio.Application.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bitci.Portfolio.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public IdentityService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<(ResultResponse Result, string UserId)> CreateUserAsync(string name, string lastName, string email, string password)
        {
            var user = new User { UserName = email, Email = email, FirstName = name, LastName = lastName };
            var result= await _userManager.CreateAsync(user,password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return (ResultResponse.Error(errors), string.Empty);
            }

            return (ResultResponse.Success(), user.Id);
        }

        public async Task<(ResultResponse Result, string Token)> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, password))
                return (ResultResponse.Error(new string[] { "Invalid Authentication" }), string.Empty);
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return (ResultResponse.Success(), token);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private List<Claim> GetClaims(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("UserId", user.Id)
            };

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires:DateTime.Now.AddDays(5),
                signingCredentials: signingCredentials);

            return tokenOptions;
        }
    }
}
