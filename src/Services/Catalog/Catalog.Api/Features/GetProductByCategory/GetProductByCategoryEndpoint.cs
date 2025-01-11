namespace Catalog.Api.Features.GetProductByCategory;

public record GetProductByCategoryRequest(string Category, int? PageNumber = 1, int? PageSize = 10);

public record GetProductByCategoryResponse(IEnumerable<Product> Products);

[ApiController]
[Route("api/v1/products/category")]
[Tags("Product")]
public class GetProductByCategoryEndpoint(ISender sender) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetProductByCategoryResponse>> GetProductByCategory([FromQuery] GetProductByCategoryRequest request, CancellationToken cancellationToken)
    {
        var mapper = new CatalogMapper();
        var query = mapper.GetProductByCategoryRequestToGetProductByCategoryQuery(request);
        var result = await sender.Send(query, cancellationToken);
        var response = mapper.GetProductByCategoryResultToGetProductByCategoryResponse(result);
        return Ok(response);
    }
}