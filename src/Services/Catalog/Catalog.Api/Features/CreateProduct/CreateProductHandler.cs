using Microsoft.Extensions.Logging;

namespace Catalog.Api.Features.CreateProduct;

public record CreateProductCommand
    (string Name, List<string> Categorys, string Description, string ImageFile, decimal Price)
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid ProductId);

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
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

internal class CreateProductCommandHandler
    (IDocumentSession session, ILogger<CreateProductCommandHandler> logger)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle
        (CreateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("CreateProductCommandHandler.Handle called with {@Command}", command);


        var product = new Product
        {
            Name = command.Name,
            Categorys = command.Categorys,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }
}
