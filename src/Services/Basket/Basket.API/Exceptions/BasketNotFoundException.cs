using BuildingBlocks.Exceptions;

namespace Basket.API.Exceptions;

public class BasketNotFoundException : NotFoundException
{
    public BasketNotFoundException(Guid customerId) : base($"Basket not found for customer with id: {customerId}")
    {
    }
}