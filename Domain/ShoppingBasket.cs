using System;
using System.Collections.Generic;

namespace Domain
{
    public class ShoppingBasket
    {
        public Guid Id { get; set; }
        public int NumberOfItems { get; set; }
        public double TotalPrice { get; set; }
        public string CustomerId { get; set; }
        public AppUser Customer { get; set; }
        public ICollection<ShoppingBasketPair> ShoppingBasketPairs { get; set; }=new List<ShoppingBasketPair>();
    }
}