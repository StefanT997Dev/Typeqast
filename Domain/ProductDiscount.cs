using System;

namespace Domain
{
    // I have decided to create an aggregated table because the admin
    // might want to have more types of discounts for the same product.
    public class ProductDiscount
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid DiscountId { get; set; }
        public Discount Discount { get; set; }
    }
}