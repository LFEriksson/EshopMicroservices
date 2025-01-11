namespace Catalog.Api.Features.GetProductByCategory;

public record GetProductByCategoryQuery(string CategoryQuery) : IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable<Product> Products);
internal class GetProductByCategoryQueryHandler(IDocumentSession session)
    : IRequestHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .Where(p => p.Categorys.Contains(query.CategoryQuery))
            .ToListAsync(cancellationToken);

        return new GetProductByCategoryResult(products);
    }
}
