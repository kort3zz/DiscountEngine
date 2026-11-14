using NewTest;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewTest
{
    public class FirstOrderDiscount : IdiscountStrategy
    {
        public string Name { get; }

        public FirstOrderDiscount()
        {
            Name = "Скидка на первый заказ 10%";
        }

        public decimal Calculate(DiscountContext context)
        {
            if (!context.Order.Customer.IsFirstOrder)
            {
                return context.CurrentTotal;
            }

            decimal discount = context.CurrentTotal * 0.10m;

            return context.CurrentTotal - discount;
        }
    }
}
