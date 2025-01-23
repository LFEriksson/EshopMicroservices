using Ordering.Application.Orders.Commands.DelteOrder;
using Ordering.Application.Orders.Commands.UpdateOrder;
using Ordering.Application.Orders.Queries.GetOrders;
using Ordering.Application.Orders.Queries.GetOrdersByCustomer;
using Ordering.Application.Orders.Queries.GetOrdersByName;
using Riok.Mapperly.Abstractions;

namespace Ordering.API;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
public partial class OrderMapper
{
    public partial CreateOrderCommand CreateOrderRequestToCreateOrderCommand(CreateOrderRequest createOrderRequest);
    public partial UpdateOrderCommand UpdateOrderRequestToUpdateOrderCommand(UpdateOrderRequest updateOrderRequest);

    public partial CreateOrderResponse CreateOrderResultToCreateOrderResponse(CreateOrderResult createOrderResult);
    public partial DeleteOrderResponse DeleteOrderResultToDeleteOrderResponse(DeleteOrderResult deleteOrderResult);
    public partial GetOrdersResponse GetOrdersResultToGetOrdersResponse(GetOrdersResult getOrdersResult);
    public partial GetOrdersByNameResponse GetOrdersByNameResultToGetOrdersByNameResponse(GetOrdersByNameResult getOrdersByNameResult);
    public partial UpdateOrderResponse UpdateOrderResultToUpdateOrderResponse(UpdateOrderResult updateOrderResult);
    public partial GetOrdersByCustomerResponse GetOrdersByCustomerResultToGetOrdersByCustomerResponse(GetOrdersByCustomerResult getOrdersByCustomerResult);
}
