using MediatR;

namespace Bitci.Portfolio.Application.Identity.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } 
    }
}
