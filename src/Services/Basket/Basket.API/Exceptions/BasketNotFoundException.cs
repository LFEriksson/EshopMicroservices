using BuildingBlocks.Exceptions;

namespace Basket.API.Exceptions;

public class BasketNotFoundException : NotFoundException
{
    public BasketNotFoundException(string customerName) : base($"Basket not found for customer with id: {customerName}")
    {
    }
}