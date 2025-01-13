namespace Basket.API.Features.StoreBasket;

public record StoreBasketRequest(ShoppingCart Cart);

public record StoreBasketResponse(Guid CustomerGuid);


[ApiController]
[Route("api/v1/baskets")]
[Tags("Basket")]
public class StoreBasketEndpoint(ISender sender) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<StoreBasketResponse>> StoreBasket
        (StoreBasketRequest request, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new StoreBasketCommand(request.Cart), cancellationToken);
        return Ok(result);
    }
}
