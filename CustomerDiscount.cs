using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTest
{
    public class CustomerDiscount : IdiscountStrategy
    {
        public string Name { get; }
        private decimal CusDis;

        public CustomerDiscount(decimal cusDis)
        {
            if (cusDis < 0)
            {
                throw new ArgumentException("Скидка не может быть отрицательной");
            }

            Name = $"Скидка постоянного клиента {cusDis} ";
            CusDis = cusDis;
        }
        public decimal Calculate(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Цена не может быть отрицательной ");
            }
            decimal NewPrice = price - CusDis;

            if (NewPrice < 0)
            {
                NewPrice = 0;
            }
            return NewPrice;
        }
    }
}
