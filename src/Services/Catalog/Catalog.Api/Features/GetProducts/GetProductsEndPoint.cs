namespace Catalog.Api.Features.GetProducts;

public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);

public record GetProductResponse(IEnumerable<Product> Products);

[ApiController]
[Route("api/v1/products")]
[Tags("Product")]
public class GetProductsEndpoint(ISender sender) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetProductResponse>> GetProducts([FromQuery] GetProductsRequest request, CancellationToken cancellationToken)
    {
        var mapper = new CatalogMapper();
        var query = mapper.GetProductsRequestToGetProductQuery(request);
        var result = await sender.Send(query, cancellationToken);
        var response = mapper.GetProductResultToGetProductResponse(result);
        return Ok(response);
    }
}