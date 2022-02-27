using FluentValidation;

namespace Bitci.Portfolio.Application.Coin.Queries.GetCoinsByUserId
{
    public class GetCoinsByUserIdQueryValidator : AbstractValidator<GetCoinsByUserIdQuery>
    {
        public GetCoinsByUserIdQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
