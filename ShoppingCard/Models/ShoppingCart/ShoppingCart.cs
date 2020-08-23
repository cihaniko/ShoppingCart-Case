using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ShoppingCard.Models.Coupon;
using ShoppingCard.Models.Campaign;

namespace ShoppingCard.Models
{
    public class ShoppingCart : IShoppingCart<Product>
    {
        public List<Product> items { get; set; }

        public double TotalPrice { get; set; }
        public double CartPrice { get; set; }

        private List<ICampaign> UsedCampaigns;
        private ICoupon _UsedCoupon=new Coupon.Coupon();
        private double _discountCoupon;
        private double _discountCampaigns;

        public ShoppingCart()
        {
            items = new List<Product>();
            UsedCampaigns = new List<ICampaign>();

    }

    /// <summary>
    /// Yeni Ürün ekle
    /// </summary>
    /// <param name="item">Ürün</param>
    /// <param name="count">Adet</param>
    public void AddItem(Product item, int count)
        {
            for (int i = 0; i < count; i++)
            {
                items.Add(item);
            }
         
            TotalPrice += item.Price * count;
            CartPrice = TotalPrice;
        }

        /// <summary>
        /// Sepete kupon tanımlame methodu
        /// </summary>
        /// <param name="coupon">Kupon</param>
        public void ApplyCoupon(ICoupon coupon)
        {
            var nPrice = coupon.CalculateCoupon(CartPrice);
            if (nPrice != CartPrice)
            {
                _UsedCoupon = coupon;
                _discountCoupon = CartPrice - nPrice;
                CartPrice = CartPrice - _discountCoupon;
            }
        }

        /// <summary>
        /// Sepete kampanya indirimleri tanımlama methodu
        /// </summary>
        /// <param name="campaigns">Kampanylar</param>
        public void ApplyDiscount(IEnumerable<ICampaign> campaigns)
        {
            ICampaign campaign = FindCampaignHighestDiscount(campaigns);

            if (campaign != null)
            {
                UsedCampaigns.Clear();
                UsedCampaigns.Add(campaign);
                CartPrice = campaign.CalculateCampign(items, TotalPrice);
                _discountCampaigns = TotalPrice - CartPrice;
            }
           

        }

        /// <summary>
        /// En yüksek indirimi sağlayan kampanyayı belirleyen method.
        /// </summary>
        /// <param name="campaigns"></param>
        /// <returns></returns>
        private ICampaign FindCampaignHighestDiscount(IEnumerable<ICampaign> campaigns)
        {
            double totalDiscount = 0;
            ICampaign applyCampaign = new Campaign.Campaign();
            foreach (var campaign in campaigns)
            {
                double dsc = TotalPrice - campaign.CalculateCampign(items, TotalPrice);

                if (dsc > totalDiscount)
                {
                    totalDiscount =  dsc;
                    applyCampaign = campaign;
                }

            }

            if (totalDiscount == 0)
            {
                return null;
            }
            return applyCampaign;
        }

        /// <summary>
        /// Alışveriş sepetindeki ürünleri listeler.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetShoppingList()
        {
            return items;
        }

        /// <summary>
        /// Teslimat sayısı
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfDeliveries()
        {
            return items.GroupBy(s => s.Category).Count();
        }

        /// <summary>
        /// Farklı ürün sayısı
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfProducts()
        {
            return items.GroupBy(s => s.Name).Count();
        }

        /// <summary>
        /// İndirimler uygulandıktan sonraki sepet tutarı
        /// </summary>
        /// <returns></returns>
        public double GetTotalAmountAfterDiscount()
        {
            return CartPrice;

        }

        /// <summary>
        /// Kupon ile yapılan indirim tutarı
        /// </summary>
        /// <returns></returns>
        public double GetCouponDiscount()
        {
            return _discountCoupon;

        }

        /// <summary>
        /// Kampanyalar ile yapılan indirim tutarı
        /// </summary>
        /// <returns></returns>
        public double GetCampaignDiscount()
        {
            return _discountCampaigns;

        }

        /// <summary>
        /// Teslimat maliyeti
        /// </summary>
        /// <returns></returns>
        public double GetDeliveryCost()
        {
            //buradaki teslimat maliyeti ve ürün maliyeti nedir nasıl hesaplanır ?  
            //Gönderilen case içerisinde bulamadığım için manuel verildi.
            DeliveryCostCalculator dcc = new DeliveryCostCalculator(1, 2, 2.99);
            return dcc.CalculateFor(this);

        }

        public void Print()
        {
            var shoppingGroupList = items.GroupBy(s => s.Category.Name).ToList();
            foreach (var group in shoppingGroupList)
            {
                ;
                Console.WriteLine($"\n{group.Key} Kategorisi ");
                Console.WriteLine($"---------------------");

                foreach (var item in group.GroupBy(s => s.Name).ToList())
                {
                    Console.WriteLine($"{item.Key} {item.Count()} Adet , Birim Fiyat : {item.First().Price}");
                }
                Console.WriteLine($"---------------------\n");

            }


            Console.WriteLine($"\nToplam Sepet Tutarı: {TotalPrice}");

            Console.WriteLine($"Kapmanya İndirimleri : {_UsedCoupon.MinPurchaceAmount} TL Alışverişe %{ _UsedCoupon.Rate } indirim:  {GetCampaignDiscount()} ");

            Console.WriteLine($"Kupon İndirimleri: {GetCouponDiscount()}");

            Console.WriteLine($"Ödenecek Tutar: {GetTotalAmountAfterDiscount()}");

            Console.WriteLine($"Teslimat Maliyeti: {GetDeliveryCost()}");


        }

    }
}
