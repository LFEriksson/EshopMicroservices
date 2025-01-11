namespace Catalog.Api.Features.GetProductByCategory;

public record GetProductByCategoryQuery(string CategoryQuary) : IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable<Product> Products);
internal class GetProductByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductByCategoryQueryHandler> logger)
    : IRequestHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByCategoryQueryHandler.Handle called with {@Query}", query);

        var products = await session.Query<Product>()
            .Where(p => p.Catagory.Contains(query.CategoryQuary))
            .ToListAsync(cancellationToken);

        return new GetProductByCategoryResult(products);
    }
}
