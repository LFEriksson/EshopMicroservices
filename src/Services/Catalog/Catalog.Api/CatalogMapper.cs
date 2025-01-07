using Riok.Mapperly.Abstractions;

namespace Catalog.Api;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
public partial class CatalogMapper
{

    public partial CreateProductCommand CreateProductRequestToCreateProductCommand(CreateProductRequest request);
    public partial CreateProductResponse CreateProductResultToCreateProductResponse(CreateProductResult result);
}
