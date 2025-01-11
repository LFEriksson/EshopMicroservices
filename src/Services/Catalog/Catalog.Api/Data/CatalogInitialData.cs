using Marten.Schema;

namespace Catalog.Api.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
        {
            return;
        }

        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellation);
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
    {
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Product 1",
            Categorys = new List<string> { "Category A", "Category B" },
            Description = "Description for Product 1",
            ImageFile = "image1.png",
            Price = 10
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Product 2",
            Categorys = new List<string> { "Category C" },
            Description = "Description for Product 2",
            ImageFile = "image2.png",
            Price = 20
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Product 3",
            Categorys = new List<string> { "Category A", "Category D" },
            Description = "Description for Product 3",
            ImageFile = "image3.png",
            Price = 30
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Product 4",
            Categorys = new List<string> { "Category B" },
            Description = "Description for Product 4",
            ImageFile = "image4.png",
            Price = 40
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "Product 5",
            Categorys = new List<string> { "Category C", "Category D" },
            Description = "Description for Product 5",
            ImageFile = "image5.png",
            Price = 50
        }
    };
}
