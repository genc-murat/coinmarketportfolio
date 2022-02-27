using AutoMapper;
using Bitci.Portfolio.Application.Common.Interfaces;
using Bitci.Portfolio.Application.Common.Models;
using MediatR;

namespace Bitci.Portfolio.Application.Listing.Queries.GetListings
{
    public class GetListingsQueryHandler : IRequestHandler<GetListingsQuery, ListingItemDto[]>
    {
        private readonly IMapper _mapper;
        private readonly ICoinMarketCapService _coinMarketCapService;
        public GetListingsQueryHandler(ICoinMarketCapService coinMarketCapService,IMapper mapper)
        {
            _mapper = mapper;
            _coinMarketCapService = coinMarketCapService;
        }
        public async Task<ListingItemDto[]> Handle(GetListingsQuery request, CancellationToken cancellationToken)
        {
            var list = await _coinMarketCapService.ListingsAsync();
            return  _mapper.Map<ListingResponseItem[], ListingItemDto[]>(list.Data);
                   
        }
    }
}
