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
            Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
            Name = "Product 1",
            Categorys = new List<string> { "Category A", "Category B" },
            Description = "Description for Product 1",
            ImageFile = "image1.png",
            Price = 250
        },
        new Product()
        {
            Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
            Name = "Product 2",
            Categorys = new List<string> { "Category C" },
            Description = "Description for Product 2",
            ImageFile = "image2.png",
            Price = 400
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
