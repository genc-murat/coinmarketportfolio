using Bitci.Portfolio.Application.Common.Models;

namespace Bitci.Portfolio.Application.Common.Interfaces
{
    public  interface ICoinMarketCapService
    {
        Task<ListingResponse> ListingsAsync();

    }
}
