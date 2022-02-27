using MediatR;

namespace Bitci.Portfolio.Application.Listing.Queries.GetListings
{
    public class GetListingsQuery : IRequest<ListingItemDto[]>
    {
    }
}
