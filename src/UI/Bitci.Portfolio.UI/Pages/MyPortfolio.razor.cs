using Bitci.Portfolio.UI.Services;
using Microsoft.AspNetCore.Components;

namespace Bitci.Portfolio.UI.Pages
{
    public partial class MyPortfolio
    {
        
        [Inject]
        public IPortfolioService PortfolioService { get; set; }
        public decimal Total { get; set; }
        public decimal CurrentTotal { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var coins = await PortfolioService.GetCoins();
            var listing = await PortfolioService.Getlistings();
            foreach (var item in coins.GroupBy(x=>x.Symbol))
            {
                Total += item.Sum(x => x.Quantity * x.PurchasePrice);

                CurrentTotal += item.Sum(x => x.Quantity * listing.FirstOrDefault(y => y.Symbol == item.Key)!.Quote.USD.Price); 
            }

        }

       
    }
}
