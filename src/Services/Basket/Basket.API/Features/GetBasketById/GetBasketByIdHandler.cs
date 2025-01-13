namespace Basket.API.Features.GetBasket;

public record GetBasketQuery(Guid CustomerId) : IQuery<GetBasketResult>;

public record GetBasketResult(ShoppingCart Cart);

public class GetBasketQueryHandler(IBasketRepository repository) : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        var basket = await repository.GetBasketById(query.CustomerId, cancellationToken);

        return new GetBasketResult(basket);
    }
}