using Bitci.Portfolio.Application.Common.Interfaces;
using MediatR;

namespace Bitci.Portfolio.Application.Identity.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IIdentityService _identityService;
        public CreateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = await _identityService.CreateUserAsync(request.Name, request.LastName, request.Email, request.Password);
            return response.UserId;
        }
    }
}
