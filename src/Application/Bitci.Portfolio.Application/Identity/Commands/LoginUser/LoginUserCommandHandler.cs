using Bitci.Portfolio.Application.Common.Interfaces;
using MediatR;

namespace Bitci.Portfolio.Application.Identity.Commands.LoginUser
{


    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IIdentityService _identityService;
        public LoginUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _identityService.LoginAsync(request.Email, request.Password);
            return response.Token;
        }
    }
}
