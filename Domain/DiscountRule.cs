using System;
using System.Collections.Generic;

namespace Domain
{
    // I have decided to go for RuleSign and RuleValue properties so that the admin
    // can in the future add custom discount rules, one for example would be 
    // RuleSign being a '+' and RuleValue '1' and that being connected to 
    // the Discount table which contains the ProductId will add 1 milk
    // to the purchase. Also we have only one table instead of creating separate
    // tables for percentage discounts and for amount discounts.
    public class DiscountRule
    {
        public Guid Id { get; set; }
        public string RuleSign { get; set; }
        public double RuleValue { get; set; }
        public ICollection<Discount> Discounts { get; set; }=new List<Discount>();
    }
}