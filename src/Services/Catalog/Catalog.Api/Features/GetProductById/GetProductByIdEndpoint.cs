namespace Catalog.Api.Features.GetProductById;

public record GetProductByIdResponse(Product Product);


[ApiController]
[Route("api/v1/products")]
[Tags("Product")]
public class GetProductByIdEndpoint(ISender sender) : ControllerBase
{
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetProductByIdResponse>> GetProductById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery(id);
        try
        {
            var result = await sender.Send(query, cancellationToken);
            var response = new GetProductByIdResponse(result.Product);
            return Ok(response);
        }
        catch (ProductNotFoundException)
        {
            return NotFound();
        }
    }
}
