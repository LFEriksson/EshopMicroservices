namespace Catalog.Api.Features.DeleteProduct;

public record DeleteProductResponse(bool IsSuccess);

[ApiController]
[Route("api/v1/products")]
[Tags("Product")]
public class DeleteProductEndpoint(ISender sender) : ControllerBase
{
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DeleteProductResponse>> DeleteProduct(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteProductCommand(id);
        try
        {
            var result = await sender.Send(command, cancellationToken);
            var response = new DeleteProductResponse(result.IsSuccess);
            return Ok(response);
        }
        catch (ProductNotFoundException)
        {
            return NotFound();
        }
    }
}
