namespace Basket.API.Features.DeleteBasket;

public record DeleteBasketResponse(bool IsSuccess);

[ApiController]
[Route("api/v1/baskets")]
[Tags("Basket")]
public class DeleteBasketEndpoint(ISender sender) : ControllerBase
{

    [HttpDelete("{username}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeleteBasketResponse>> DeleteBasket(string UserName)
    {
        var result = await sender.Send(new DeleteBasketCommand(UserName));
        return Ok(new DeleteBasketResponse(result.IsSuccess));
    }
}