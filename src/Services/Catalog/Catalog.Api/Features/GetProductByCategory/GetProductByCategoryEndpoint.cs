namespace Catalog.Api.Features.GetProductByCategory;

public record GetProductByCategoryResponse(IEnumerable<Product> Products);

[ApiController]
[Route("api/v1/products/category")]
[Tags("Product")]
public class GetProductByCategoryEndpoint(ISender sender) : ControllerBase
{
    [HttpGet("{category}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetProductByCategoryResponse>> GetProductByCategory(string category, CancellationToken cancellationToken)
    {
        var query = new GetProductByCategoryQuery(category);
        try
        {
            var result = await sender.Send(query, cancellationToken);
            var response = new GetProductByCategoryResponse(result.Products);
            return Ok(response);
        }
        catch (ProductNotFoundException)
        {
            return NotFound();
        }
    }
}
