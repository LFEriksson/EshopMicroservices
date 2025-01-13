namespace Basket.API.Features.GetBasket;

public record GetBasketByIdResponse(ShoppingCart Cart);

[ApiController]
[Route("api/v1/baskets")]
[Tags("Basket")]
public class GetBasketByIdEndpoint(ISender sender) : ControllerBase
{
    [HttpGet("{customerId}")]
    public async Task<ActionResult<GetBasketByIdResponse>> GetBasketById(Guid customerId)
    {
        var result = await sender.Send(new GetBasketQuery(customerId));
        return Ok(new GetBasketByIdResponse(result.Cart));
    }
}