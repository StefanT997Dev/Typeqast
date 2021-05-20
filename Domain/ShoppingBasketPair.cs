using System;

namespace Domain
{
    public class ShoppingBasketPair
    {
        public string CustomerId { get; set; }
        public AppUser Customer { get; set; }
        public Guid ProductId { get; set; }
        public Product Product{get;set;}
        public int Amount { get; set; }
        public ShoppingBasket ShoppingBasket { get; set; }
    }
}