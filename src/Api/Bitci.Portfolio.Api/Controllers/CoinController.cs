using Bitci.Portfolio.Application.Coin.Commands.AddCoin;
using Bitci.Portfolio.Application.Coin.Queries.GetCoinsByUserId;
using Bitci.Portfolio.Application.Common.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bitci.Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : BaseApiController
    {
        [HttpPost]
        public async  Task<ActionResult<bool>>  Add([FromBody]AddCoinCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<CoinDto[]>> GetByUserId(string userId)
        {
            return await Mediator.Send(new GetCoinsByUserIdQuery { UserId=userId });
        }
    }
}
