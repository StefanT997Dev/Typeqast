using System;
using System.Collections.Generic;

namespace Domain
{
    public class Discount
    {
        public Guid Id { get; set; }
        public DiscountRule DiscountRule { get; set; }
        public ICollection<ProductDiscount> Products { get; set; }
    }
}