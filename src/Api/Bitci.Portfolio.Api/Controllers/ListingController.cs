using Bitci.Portfolio.Application.Listing.Queries.GetListings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bitci.Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ListingController : BaseApiController
    {
        [HttpGet()]
        public async Task<ActionResult<ListingItemDto[]>> Get()
        {
            return await Mediator.Send(new GetListingsQuery());
        }
    }
}
