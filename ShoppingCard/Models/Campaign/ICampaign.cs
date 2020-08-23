using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard.Models.Campaign
{
    public interface ICampaign
    {
        Category Category { get; }
        double DiscountRate { get; }
        double ProductCount { get; }

        DiscountType DiscountType { get; }

        double CalculateCampign(List<Product> items,double totalPrice);
    }
}
