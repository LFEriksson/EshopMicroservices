namespace Basket.API.Features.CheckoutBasket;

public record CheckoutBasketRequest(BasketCheckoutDto BasketCheckoutDto);
public record CheckoutBasketResponse(bool IsSuccess);


[ApiController]
[Route("api/v1/baskets/checkout")]
[Tags("Basket")]
public class CheckoutBasketEndpoints(ISender sender) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CheckoutBasketResponse>> CheckoutBasket
        (CheckoutBasketRequest request, CancellationToken cancellationToken)
    {
        var mapper = new BasketMapper();
        var command = mapper.CheckoutBasketRequestToCheckoutBasketCommand(request);

        var result = await sender.Send(command);

        var response = mapper.CheckoutBasketResultToCheckoutBasketResponse(result);

        return Ok(response);
    }
}