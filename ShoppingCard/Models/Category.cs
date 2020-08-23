using ShoppingCard.Models.Campaign;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCard.Models
{
    public class Category
    {
        //private readonly string name;
        //private readonly string topCategory;
        public string Name { get; }
        public string TopCategory { get; }

        public List<ICampaign> CampaignList { get; }

        public Category(string name, string topCategory)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Kategori ismi boş olamaz.", nameof(name));
            }
            this.Name = name;

            if (string.IsNullOrEmpty(topCategory))
            {
                this.TopCategory = "";
            }
            else
                this.TopCategory = topCategory;
            Name = name;
            TopCategory = topCategory;
        }

        public Category(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("message", nameof(name));
            }
            this.Name = name;

        }
    }
}
