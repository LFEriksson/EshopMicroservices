using Catalog.Api.Features.GetProductByCategory;
using Catalog.Api.Features.GetProducts;
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

    public partial GetProductQuery GetProductsRequestToGetProductQuery(GetProductsRequest request);
    public partial GetProductResponse GetProductResultToGetProductResponse(GetProductResult result);

    public partial GetProductByCategoryQuery GetProductByCategoryRequestToGetProductByCategoryQuery(GetProductByCategoryRequest request);
    public partial GetProductByCategoryResponse GetProductByCategoryResultToGetProductByCategoryResponse(GetProductByCategoryResult result);
}
