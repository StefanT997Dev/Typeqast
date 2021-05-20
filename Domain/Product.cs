using System;
using System.Collections.Generic;

namespace Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string PackageSize { get; set; }
        public string Name { get; set; }
        public int AmountLeft { get; set; }
        public double Price { get; set; }
        public ICollection<ProductDiscount> Discounts { get; set; }=new List<ProductDiscount>();
        public ICollection<ShoppingBasketPair> Customers { get; set; }=new List<ShoppingBasketPair>();
    }
}