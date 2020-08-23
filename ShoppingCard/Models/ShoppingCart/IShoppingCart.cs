using ShoppingCard.Models.Campaign;
using ShoppingCard.Models.Coupon;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard.Models
{

    public enum DiscountType
    {
        Rate,
        Amount
    }

    public interface IShoppingCart<T>
    {
        List<T> items { get; }

        double TotalPrice { get; }
        List<T> GetShoppingList();

        void AddItem(T item, int count);

        void ApplyDiscount(IEnumerable<ICampaign> campaigns);
        void ApplyCoupon(ICoupon campaigns);



    }
}
