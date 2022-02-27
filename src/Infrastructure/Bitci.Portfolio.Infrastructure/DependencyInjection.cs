
using Bitci.Portfolio.Application.Common.Interfaces;
using Bitci.Portfolio.Application.Common.Repositories;
using Bitci.Portfolio.Infrastructure.CoinMarketCap;
using Bitci.Portfolio.Infrastructure.Identity;
using Bitci.Portfolio.Infrastructure.Persistence;
using Bitci.Portfolio.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Polly;

namespace Bitci.Portfolio.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PortfolioDbContext>(options =>
            options.UseInMemoryDatabase("Portfolio"));
        services.AddIdentityCore<User>(options =>
        {
            options.SignIn.RequireConfirmedEmail = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 1;
            options.Password.RequiredUniqueChars = 0;

        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<PortfolioDbContext>();

        services.AddScoped<ICoinRepository, CoinRepository>();

        services.AddTransient<IIdentityService, IdentityService>();

        services.AddHttpClient<ICoinMarketCapService, CoinMarketCapService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(configuration["CoinMarketCap:Url"]);

            httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Accept, "application/json");
            httpClient.DefaultRequestHeaders.Add(
                "X-CMC_PRO_API_KEY", configuration["CoinMarketCap:ApiKey"]);
        }).AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
        {
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(5)
        }));
        return services;
    }
}

