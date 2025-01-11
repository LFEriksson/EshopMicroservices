namespace Catalog.Api.Features.UpdateProduct;

public record UpdateProductCommand
    (Guid id, string Name, List<string> Categorys, string Description, string ImageFile, decimal Price)
    : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.id)
            .NotEqual(Guid.Empty)
            .WithMessage("Product id is required.");
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Product name is required.");
        RuleFor(x => x.Categorys)
            .NotEmpty()
            .WithMessage("At least one category is required.");
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Product description is required.");
        RuleFor(x => x.ImageFile)
            .NotEmpty()
            .WithMessage("Image file is required.");
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0.");
    }
}

internal class UpdateProductComandHandler(IDocumentSession session, ILogger<UpdateProductComandHandler> logger)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle
        (UpdateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateProductComandHandler.Handle called with {@Comand}", command);

        var product = await session.LoadAsync<Product>(command.id, cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(command.id);
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
