using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard.Models.Coupon
{
    public interface ICoupon
    {
        double MinPurchaceAmount { get; }
        double Rate { get; }
        DiscountType DiscountType { get; }
        double CalculateCoupon(double totalPrice);
    }
}
