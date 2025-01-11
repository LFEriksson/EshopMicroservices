﻿namespace Catalog.Api.Features.UpdateProduct;

public record UpdateProductCommand
    (Guid id, string Name, List<string> Categorys, string Description, string ImageFile, decimal Price)
    : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);

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
