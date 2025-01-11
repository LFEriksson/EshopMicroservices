namespace Catalog.Api.Features.GetProducts;

public record GetProductResponse(IEnumerable<Product> Products);

[ApiController]
[Route("api/v1/products")]
[Tags("Product")]
public class GetProductsEndpoint(ISender sender) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetProductResponse>> GetProducts(CancellationToken cancellationToken)
    {
        var query = new GetProductQuery();
        var result = await sender.Send(query, cancellationToken);
        var response = new GetProductResponse(result.Products);
        return Ok(response);
    }
}