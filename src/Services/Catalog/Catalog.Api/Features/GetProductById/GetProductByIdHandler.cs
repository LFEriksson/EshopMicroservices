namespace Catalog.Api.Features.GetProductById;

public record GetProductByIdQuery(Guid Guid) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);

internal class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger)
    : IRequestHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByIdQueryHandler.Handle called with {@Query}", query);

        var product = await session.LoadAsync<Product>(query.Guid, cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(query.Guid);
        }

        return new GetProductByIdResult(product);
    }
}
