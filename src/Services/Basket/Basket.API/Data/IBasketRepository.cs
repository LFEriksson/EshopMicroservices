namespace Basket.API.Data;

public interface IBasketRepository
{
    Task<ShoppingCart> GetBasketById(Guid customerId, CancellationToken cancellationToken = default!);

    Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default!);

    Task<bool> DeleteBasket(Guid customerId, CancellationToken cancellationToken = default!);
}
