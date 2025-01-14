using Dicount.Grpc.Data;
using Dicount.Grpc.Models;
using Discount.Grpc;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Dicount.Grpc.Services;

public class DiscountService
    (DiscountContext dbContext, ILogger<DiscountService> logger)
    : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

        if (coupon is null)
        {
            coupon = new Coupon() { Description = "No Discount Description", ProductName = "No Discount", DicountAmount = 0 };
        }

        logger.LogInformation("Discount is retrieved for ProductName : {productName}, Amount : {amount}", coupon.ProductName, coupon.DicountAmount);

        var mapper = new DiscountMapper();
        return mapper.CouponToCouponModel(coupon);
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var mapper = new DiscountMapper();
        var coupon = mapper.CouponModelToCoupon(request.Coupon);
        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Coupon is null"));
        }

        dbContext.Coupons.Add(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Discount is successfully created. ProductName : {productName}", coupon.ProductName);
        return mapper.CouponToCouponModel(coupon);
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var mapper = new DiscountMapper();
        var coupon = mapper.CouponModelToCoupon(request.Coupon);
        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Coupon is null"));
        }

        dbContext.Coupons.Update(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Discount is successfully updated. ProductName : {productName}", coupon.ProductName);
        return mapper.CouponToCouponModel(coupon);
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, "Discount not found"));
        }
        dbContext.Coupons.Remove(coupon);
        await dbContext.SaveChangesAsync();
        logger.LogInformation("Discount is successfully deleted. ProductName : {productName}", coupon.ProductName);
        return new DeleteDiscountResponse { Success = true };
    }
}