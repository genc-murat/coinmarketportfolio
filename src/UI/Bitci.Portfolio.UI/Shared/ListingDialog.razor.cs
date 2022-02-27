using Bitci.Portfolio.Application.Common.DTOs;
using Bitci.Portfolio.Application.Listing.Queries.GetListings;
using Bitci.Portfolio.UI.Services;
using Microsoft.AspNetCore.Components;

namespace Bitci.Portfolio.UI.Shared
{
    public partial class ListingDialog : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public ListingItemDto[] Coins { get; set; }
        public ListingItemDto SelectedCoin { get; set; }
        public CoinDto AddCoin { get; set; }
        public bool ShowDialog { get; set; }
        public bool AddDialog { get; set; }
        [Inject]
        public IPortfolioService PortfolioService { get; set; }
        public EventCallback<bool> CloseEventCallback { get; set; }

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }
        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }
        private void ResetDialog()
        {

        }


        public void Select(ListingItemDto coin)
        {
            SelectedCoin = coin;
            AddCoin = new CoinDto { Symbol = SelectedCoin.Symbol, Name = SelectedCoin.Name, PurchaseDate=DateTime.Now };
            AddDialog = true;
            ShowDialog = false;
        }


        protected override async Task OnInitializedAsync()
        {
            Coins = await PortfolioService.Getlistings();

        }
        protected async Task HandleValidSubmit()
        {
            //ekleme işlemi yapılacak
            ShowDialog = false;
            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }

        public async Task ExecuteAddCoin()
        {
            await PortfolioService.AddCoin(AddCoin);
            NavigationManager.NavigateTo("/myassets");
            //ShowAuthError = false;

            //var result = await AuthenticationService.Login(_userForAuthentication);
            //if (!result.IsAuthSuccessful)
            //{
            //    Error = result.ErrorMessage;
            //    ShowAuthError = true;
            //}
            //else
            //{
            //    NavigationManager.NavigateTo("/");
            //}
        }
    }
}
