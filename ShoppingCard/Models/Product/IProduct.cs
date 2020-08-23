using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard.Models
{
    public interface IProduct
    {
        string Name { get; }
        Category Category { get; }
        double Price { get; }
    }
}
