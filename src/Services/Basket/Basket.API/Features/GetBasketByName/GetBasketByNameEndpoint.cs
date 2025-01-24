namespace Basket.API.Features.GetBasket;

public record GetBasketByIdResponse(ShoppingCart Cart);

[ApiController]
[Route("api/v1/baskets")]
[Tags("Basket")]
public class GetBasketByNameEndpoint(ISender sender) : ControllerBase
{
    [HttpGet("{username}")]
    public async Task<ActionResult<GetBasketByIdResponse>> GetBasketById(string UserName)
    {
        var result = await sender.Send(new GetBasketQuery(UserName));
        return Ok(new GetBasketByIdResponse(result.Cart));
    }
}