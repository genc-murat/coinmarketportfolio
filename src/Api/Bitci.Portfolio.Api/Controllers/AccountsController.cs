using Bitci.Portfolio.Application.Identity.Commands.CreateUser;
using Bitci.Portfolio.Application.Identity.Commands.LoginUser;
using Microsoft.AspNetCore.Mvc;

namespace Bitci.Portfolio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseApiController
    {

        [HttpPost("create")]
        public async Task<ActionResult<string>> Post([FromBody]CreateUserCommand userCommand)
        {
            return await Mediator.Send(userCommand);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginUserCommand userCommand)
        {
            return await Mediator.Send(userCommand);
        }
    }
}
