namespace Catalog.Api.Features.UpdateProduct;

public record UpdateProductRequest(Guid id, string Name, List<string> Catagory, string Description, string ImageFile, decimal Price);

public record UpdateProductResponse(bool IsSuccess);

[ApiController]
[Route("api/v1/products")]
[Tags("Product")]
public class UpdateProductEndpoint(ISender sender) : ControllerBase
{
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UpdateProductResponse>> UpdateProduct
        (UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var mapper = new CatalogMapper();
        var command = mapper.UpdateProductRequestToUpdateProductCommand(request);

        var result = await sender.Send(command, cancellationToken);
        var response = mapper.UpdateProductResultToUpdateProductResponse(result);

        return Ok(response);
    }
}