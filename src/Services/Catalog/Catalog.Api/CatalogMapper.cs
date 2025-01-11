using Catalog.Api.Features.UpdateProduct;
using Riok.Mapperly.Abstractions;

namespace Catalog.Api;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
public partial class CatalogMapper
{

    public partial CreateProductCommand CreateProductRequestToCreateProductCommand(CreateProductRequest request);
    public partial CreateProductResponse CreateProductResultToCreateProductResponse(CreateProductResult result);

    public partial UpdateProductCommand UpdateProductRequestToUpdateProductCommand(UpdateProductRequest request);
    public partial UpdateProductResponse UpdateProductResultToUpdateProductResponse(UpdateProductResult result);
}
