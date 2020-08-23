using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ShoppingCard.Models.Campaign
{
    public class Campaign : ICampaign
    {
        public Category Category { get; }
        public double DiscountRate { get; }
        public double ProductCount { get; }
        public DiscountType DiscountType { get; }

        public Campaign()
        {

        }
        public Campaign(Category category, double discountRate, double productCount, DiscountType discountType)
        {
            Category = category;
            DiscountRate = discountRate;
            ProductCount = productCount;
            DiscountType = discountType;
        }
     
        /// <summary>
        /// Kampanya indirim tutarı hesaplama methodu
        /// </summary>
        /// <param name="items"></param>
        /// <param name="totalPrice"></param>
        /// <returns></returns>
        public double CalculateCampign(List<Product> items,double totalPrice)
        {
            var productCatCount = items.Where(s => s.Category.Name == Category.Name).Count();
            
            if (productCatCount <= ProductCount)
            {
                return totalPrice;
            }

            switch (DiscountType)
            {
                case DiscountType.Amount:
                    return totalPrice - DiscountRate;

                case DiscountType.Rate:
                    return totalPrice-(totalPrice * (DiscountRate/100));

                default:
                    return totalPrice;
            }
        }

  
    }
}
