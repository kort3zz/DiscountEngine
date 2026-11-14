using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTest
{
    class DiscountFactory
    {
        public static IdiscountStrategy CreatePercentage(int percent)
        {
            return new PercentageDiscount(percent);
        }

        public static IdiscountStrategy CreateFixed(decimal amount)
        {
            return new FixedDiscount(amount);
        }

        public static IdiscountStrategy CreateCustomer(decimal cusDis)
        {
            return new CustomerDiscount(cusDis);
        }
    }

}
