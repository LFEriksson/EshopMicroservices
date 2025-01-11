using Marten.Pagination;

namespace Catalog.Api.Features.GetProductByCategory;

public record GetProductByCategoryQuery(string Category, int PageNumber, int PageSize) : IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable<Product> Products);
internal class GetProductByCategoryQueryHandler(IDocumentSession session)
    : IRequestHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
            .Where(p => p.Categorys.Contains(query.Category))
            .ToPagedListAsync(query.PageNumber, query.PageSize, cancellationToken);

        return new GetProductByCategoryResult(products);
    }
}
