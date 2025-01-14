using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.API.Data;

public class CachedBasketRepository
    (IBasketRepository repository, IDistributedCache cache)
    : IBasketRepository
{
    public async Task<ShoppingCart> GetBasketById(Guid customerId, CancellationToken cancellationToken = default)
    {
        var cachedBasket = await cache.GetStringAsync(customerId.ToString(), cancellationToken);

        if (!string.IsNullOrEmpty(cachedBasket))
        {
            return JsonSerializer.Deserialize<ShoppingCart>(cachedBasket)!;
        }

        var basket = await repository.GetBasketById(customerId, cancellationToken);
        await cache.SetStringAsync(customerId.ToString(), JsonSerializer.Serialize(basket), cancellationToken);
        return basket;
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        await repository.StoreBasket(basket, cancellationToken);
        await cache.SetStringAsync(basket.CustomerId.ToString(), JsonSerializer.Serialize(basket), cancellationToken);

        return basket;
    }

    public async Task<bool> DeleteBasket(Guid customerId, CancellationToken cancellationToken = default)
    {
        await cache.RemoveAsync(customerId.ToString(), cancellationToken);
        return await repository.DeleteBasket(customerId, cancellationToken);
    }
}
