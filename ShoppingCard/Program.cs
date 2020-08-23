using ShoppingCard.Models;
using ShoppingCard.Models.Campaign;
using ShoppingCard.Models.Coupon;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCard
{
    class Program
    {


        static void Main(string[] args)
        {

            Category cat1 = new Category("Giysi");
            Category cat2 = new Category("Teknoloji");

            Product urun1 = new Product("Ayakkabı", 150, cat1);
            Product urun2 = new Product("Gömlek", 50, cat1);
            Product urun3 = new Product("T-shirt", 20, cat1);

            Product urun4 = new Product("Klavye", 50, cat2);
            Product urun5 = new Product("Mouse", 50, cat2);
            Product urun6 = new Product("Laptop", 1220, cat2);

            Campaign cmp1 = new Campaign(cat1, 10, 2, DiscountType.Rate);
            Campaign cmp2 = new Campaign(cat1, 20, 3, DiscountType.Rate);
            Campaign cmp3 = new Campaign(cat1, 10, 1, DiscountType.Amount);


            ShoppingCart _shoppingCart;

            _shoppingCart = new ShoppingCart();

            _shoppingCart.AddItem(urun1, 1);
            _shoppingCart.AddItem(urun2, 3);
            _shoppingCart.AddItem(urun3, 3);
            _shoppingCart.AddItem(urun4, 1);

            List<Campaign> listCampaing = new List<Campaign>() { cmp1, cmp2, cmp3 };

            _shoppingCart.ApplyDiscount(listCampaing);

            Coupon kupon1 = new Coupon(500, 30, DiscountType.Rate);
            _shoppingCart.ApplyCoupon(kupon1);

            _shoppingCart.Print();


            Console.ReadKey();
            Console.ReadKey();
            Console.ReadKey();

        }
    }
}
