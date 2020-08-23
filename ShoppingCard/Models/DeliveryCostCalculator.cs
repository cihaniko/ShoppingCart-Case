using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard.Models
{
    public class DeliveryCostCalculator
    {
        private readonly double costPerDelivery;
        private readonly double costPerProduct;
        private readonly double fixedCost;

    
        public DeliveryCostCalculator(double costPerDelivery,double costPerProduct,double fixedCost)
        {
            this.costPerDelivery = costPerDelivery;
            this.costPerProduct = costPerProduct;
            this.fixedCost = fixedCost;
        }

        /// <summary>
        /// teslimat maliyeti hesaplama methodu 
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        public double CalculateFor(ShoppingCart cart)
        {
            return (costPerDelivery * cart.GetNumberOfDeliveries()) + (costPerProduct * cart.GetNumberOfProducts()) + fixedCost;
        }

     
    }
}
