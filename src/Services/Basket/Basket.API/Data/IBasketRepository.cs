namespace Basket.API.Data;

public interface IBasketRepository
{
    Task<ShoppingCart> GetBasketByName(string customerName, CancellationToken cancellationToken = default!);

    Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default!);

    Task<bool> DeleteBasket(string customerName, CancellationToken cancellationToken = default!);
}
