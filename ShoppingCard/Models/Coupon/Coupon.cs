using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard.Models.Coupon
{
    public class Coupon:ICoupon
    {

        public double MinPurchaceAmount { get; }
        public double Rate { get; }
        public DiscountType DiscountType { get; }

        public Coupon()
        {

        }
        public Coupon(double minPurchaceAmount, double rate, DiscountType discountType)
        {
            MinPurchaceAmount = minPurchaceAmount;
            Rate = rate;
            DiscountType = discountType;
        }
        /// <summary>
        /// Kupon indirim tutarı hesaplama methodu
        /// </summary>
        /// <param name="totalPrice"></param>
        /// <returns></returns>
        public double CalculateCoupon(double totalPrice)
        {
            if (totalPrice < MinPurchaceAmount)
            {
                return totalPrice;
            }

            switch (DiscountType)
            {
                case DiscountType.Amount:
                    return totalPrice - Rate;

                case DiscountType.Rate:
                    return totalPrice - (totalPrice * (Rate / 100));

                default:
                    return totalPrice;
            }

        }

    }
}
