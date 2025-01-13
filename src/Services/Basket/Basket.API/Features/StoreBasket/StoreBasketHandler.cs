namespace Basket.API.Features.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;

public record StoreBasketResult(bool IsSuccess);

public class StoreBasketValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketValidator()
    {
        RuleFor(x => x.Cart)
            .NotNull()
            .WithMessage("Cart is required.");

        RuleFor(x => x.Cart.CustomerId)
            .NotEmpty()
            .WithMessage("CustomerId is required.");
    }
}

public class StoreBasketcommandHandler(IBasketRepository repository)
    : ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        await repository.StoreBasket(command.Cart, cancellationToken);

        return new StoreBasketResult(true);
    }
}