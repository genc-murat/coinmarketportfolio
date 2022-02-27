using FluentValidation;

namespace Bitci.Portfolio.Application.Coin.Commands.AddCoin
{

    public class AddCoinCommandValidator : AbstractValidator<AddCoinCommand>
    {
        public AddCoinCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty();
            RuleFor(u => u.UserId).NotEmpty();
            RuleFor(u => u.Symbol).NotEmpty();
            RuleFor(u => u.Quantity).NotEmpty();
            RuleFor(u => u.PurchaseDate).NotEmpty();
            RuleFor(u => u.PurchasePrice).NotEmpty();
        }
    }
}
