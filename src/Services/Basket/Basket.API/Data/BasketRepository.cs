namespace Basket.API.Data;

public class BasketRepository(IDocumentSession session) : IBasketRepository
{
    public async Task<ShoppingCart> GetBasketById(Guid customerId, CancellationToken cancellationToken = default)
    {
        var basket = await session.LoadAsync<ShoppingCart>(customerId, cancellationToken);
        return basket is null ? throw new BasketNotFoundException(customerId) : basket;
    }
    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        session.Store(basket);
        await session.SaveChangesAsync(cancellationToken);
        return basket;

    }

    public async Task<bool> DeleteBasket(Guid customerId, CancellationToken cancellationToken = default)
    {
        session.Delete<ShoppingCart>(customerId);
        await session.SaveChangesAsync(cancellationToken);
        return true;
    }
}
