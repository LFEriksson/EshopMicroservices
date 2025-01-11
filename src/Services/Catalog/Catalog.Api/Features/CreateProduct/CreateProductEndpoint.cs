namespace Catalog.Api.Features.CreateProduct;

public record CreateProductRequest
    (string Name, List<string> Categorys, string Description, string ImageFile, decimal Price);

public record CreateProductResponse(Guid ProductId);


[ApiController]
[Route("api/v1/products")]
[Tags("Product")]
public class CreateProductEndpoint(ISender sender) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateProductResponse>> CreateProduct
        (CreateProductRequest request, CancellationToken cancellationToken)
    {
        var mapper = new CatalogMapper();
        var command = mapper.CreateProductRequestToCreateProductCommand(request);

        var result = await sender.Send(command, cancellationToken);

        var response = mapper.CreateProductResultToCreateProductResponse(result);

        return Created($"/api/v1/product/{response.ProductId}", response);
    }
}
