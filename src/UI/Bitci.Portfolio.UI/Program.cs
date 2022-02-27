using Bitci.Portfolio.UI;
using Bitci.Portfolio.UI.AuthProviders;
using Bitci.Portfolio.UI.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddHttpClient();
//builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddHttpClient<IAuthenticationService, AuthenticationService>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["IdentityService:Url"]);

});
builder.Services.AddHttpClient<IPortfolioService, PortfolioService>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["PortfolioService:Url"]);

});
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

await builder.Build().RunAsync();
