namespace Basket.API.Features.DeleteBasket;

public record DeleteBasketResponse(bool IsSuccess);

[ApiController]
[Route("api/v1/baskets")]
[Tags("Basket")]
public class DeleteBasketEndpoint(ISender sender) : ControllerBase
{

    [HttpDelete("{customerId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeleteBasketResponse>> DeleteBasket(Guid customerId)
    {
        var result = await sender.Send(new DeleteBasketCommand(customerId));
        return Ok(new DeleteBasketResponse(result.IsSuccess));
    }
}