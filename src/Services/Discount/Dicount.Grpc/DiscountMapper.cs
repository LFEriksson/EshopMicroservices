using Dicount.Grpc.Models;
using Discount.Grpc;
using Riok.Mapperly.Abstractions;

namespace Dicount.Grpc;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
public partial class DiscountMapper
{
    public partial CouponModel CouponToCouponModel(Coupon coupon);
    public partial Coupon CouponModelToCoupon(CouponModel couponModel);
}
