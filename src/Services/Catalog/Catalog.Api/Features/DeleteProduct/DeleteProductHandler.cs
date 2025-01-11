namespace Catalog.Api.Features.DeleteProduct;

public record DeleteProductCommand(Guid Guid) : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);

internal class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(x => x.Guid)
            .NotEqual(Guid.Empty)
            .WithMessage("Product id is required.");
    }
}

internal class DeleteProductcommandHandler(IDocumentSession session)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle
        (DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Guid, cancellationToken);
        if (product is null)
        {
            throw new ProductNotFoundException(command.Guid);
        }
        session.Delete(product);
        await session.SaveChangesAsync(cancellationToken);
        return new DeleteProductResult(true);
    }
}