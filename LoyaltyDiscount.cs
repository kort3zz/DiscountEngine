using System;
using System.Collections.Generic;
using System.Text;

namespace NewTest
{
    public class LoyaltyDiscount : IdiscountStrategy
    {
        public string Name { get; }

        public LoyaltyDiscount()
        {
            Name = "Скидка постоянного клиента 5%";
        }

        public decimal Calculate(DiscountContext context)
        {
            DateTime? lastPurchase = context.Order.Customer.LastPurchaseDate;

            if (lastPurchase == null)
            {
                return context.CurrentTotal;
            }

            int daysPassed = (context.Order.OrderDate - lastPurchase.Value).Days;

            if (daysPassed < 0 || daysPassed > 30)
            {
                return context.CurrentTotal;
            }

            decimal discount = context.CurrentTotal * 0.05m;

            return context.CurrentTotal - discount;
        }
    }
}
