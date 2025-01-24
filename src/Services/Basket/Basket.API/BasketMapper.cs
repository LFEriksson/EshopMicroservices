using Basket.API.Features.CheckoutBasket;
using BuildingBlocks.Messaging.Events;
using Riok.Mapperly.Abstractions;

namespace Basket.API;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
public partial class BasketMapper
{
    public partial BasketCheckoutEvent BasketCheckoutDtoToBasketCheckoutEvent(BasketCheckoutDto basketCheckoutDto);

    public partial CheckoutBasketCommand CheckoutBasketRequestToCheckoutBasketCommand(CheckoutBasketRequest checkoutBasketRequest);

    public partial CheckoutBasketResponse CheckoutBasketResultToCheckoutBasketResponse(CheckoutBasketResult checkoutBasketResult);
}
