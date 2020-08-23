using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard.Models
{
    public class Product: IProduct
    {
    
        public string Name { get; }
        public double Price { get; }
        public Category Category { get; }


        public Product(string name,double price,Category category)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("message", nameof(name));
            }

            Name = name;
            Price = price;
            Category = category;
            Price = price;
            Category = category;
            Name = name;
        }


    }
}
