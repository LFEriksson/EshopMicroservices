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

public record UpdateProductCommand
    (Guid id, string Name, List<string> Categorys, string Description, string ImageFile, decimal Price)
    : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);

internal class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle
        (UpdateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateProductCommandHandler.Handle called with {@Command}", command);

        var product = await session.LoadAsync<Product>(command.id, cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException();
        }

        product.Name = command.Name;
        product.Categorys = command.Categorys;
        product.Description = command.Description;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}
