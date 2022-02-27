using Bitci.Portfolio.Application.Common.DTOs;
using Bitci.Portfolio.Application.Listing.Queries.GetListings;
using Bitci.Portfolio.UI.Services;
using Microsoft.AspNetCore.Components;

namespace Bitci.Portfolio.UI.Pages
{
    public partial class MyAssets
    {
        [Inject]
        public IPortfolioService PortfolioService { get; set; }

        public CoinDto[] Coins { get; set; }

        public ListingItemDto[] Listings { get; set; }

        public  ListingItemDto GetListingItem(string key)
        {
            return  Listings.FirstOrDefault(x => x.Symbol == key)!;
        }

        protected override async Task OnInitializedAsync()
        {
            Coins= await PortfolioService.GetCoins();
            Listings = await PortfolioService.Getlistings();
        }
    }
}
