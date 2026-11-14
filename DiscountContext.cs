using System;
using System.Collections.Generic;
using System.Text;

namespace NewTest
{
    public class DiscountContext
    {
        public Order Order { get; private set; }
        public decimal CurrentTotal { get; set; }

        public DiscountContext(Order order, decimal currentTotal)
        {
            Order = order;
            CurrentTotal = currentTotal;
        }
    }
}
