﻿namespace Ordering.Infrastructure.Data.Extensions;

internal class InitialData
{
    public static IEnumerable<Customer> Customers =>
    new List<Customer>
    {
        Customer.Create(CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")), "mehmet", "mehmet@gmail.com"),
        Customer.Create(CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")), "john", "john@gmail.com"),
        Customer.Create(CustomerId.Of(new Guid("a3c49479-ec65-4de2-86e7-033c546291bb")), "alice", "alice@gmail.com")
    };

    public static IEnumerable<Product> Products =>
        new List<Product>
        {
            Product.Create(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), "IPhone X", 500),
            Product.Create(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), "Samsung 10", 400),
            Product.Create(ProductId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8")), "Huawei Plus", 650),
            Product.Create(ProductId.Of(new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27")), "Xiaomi Mi", 450),
            Product.Create(ProductId.Of(new Guid("7ec1297b-ec0a-4aa1-be25-6726e3b51a28")), "OnePlus 8", 550)
        };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("mehmet", "ozkaya", "mehmet@gmail.com", "Bahcelievler No:4", "Turkey", "Istanbul", "38050");
            var address2 = Address.Of("john", "doe", "john@gmail.com", "Broadway No:1", "England", "Nottingham", "08050");
            var address3 = Address.Of("alice", "smith", "alice@gmail.com", "Main St No:10", "USA", "New York", "10001"); // New address

            var payment1 = Payment.Of("mehmet", "5555555555554444", "12/28", "355", 1);
            var payment2 = Payment.Of("john", "8885555555554444", "06/30", "222", 2);
            var payment3 = Payment.Of("alice", "9995555555554444", "11/29", "123", 3);

            var order1 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")),
                            OrderName.Of("ORD_1"),
                            shippingAddress: address1,
                            billingAddress: address1,
                            payment1);
            order1.Add(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), 2, 500);
            order1.Add(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), 1, 400);

            var order2 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")),
                            OrderName.Of("ORD_2"),
                            shippingAddress: address2,
                            billingAddress: address2,
                            payment2);
            order2.Add(ProductId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8")), 1, 650);
            order2.Add(ProductId.Of(new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27")), 2, 450);

            var order3 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("a3c49479-ec65-4de2-86e7-033c546291bb")),
                            OrderName.Of("ORD_3"),
                            shippingAddress: address3,
                            billingAddress: address3,
                            payment3);
            order3.Add(ProductId.Of(new Guid("7ec1297b-ec0a-4aa1-be25-6726e3b51a28")), 1, 550);

            var order4 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")),
                            OrderName.Of("ORD_4"),
                            shippingAddress: address1,
                            billingAddress: address1,
                            payment1);
            order4.Add(ProductId.Of(new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8")), 1, 650);
            order4.Add(ProductId.Of(new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27")), 1, 450);

            var order5 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("189dc8dc-990f-48e0-a37b-e6f2b60b9d7d")),
                            OrderName.Of("ORD_5"),
                            shippingAddress: address2,
                            billingAddress: address2,
                            payment2);
            order5.Add(ProductId.Of(new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61")), 3, 500);
            order5.Add(ProductId.Of(new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914")), 2, 400);

            return new List<Order> { order1, order2, order3, order4, order5 };
        }
    }
}
