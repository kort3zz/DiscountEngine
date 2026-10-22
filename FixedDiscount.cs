using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTest
{
    class FixedDiscount : IdiscountStrategy
    {
        public string Name { get; }
        private decimal amount;

        public FixedDiscount(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Размер скидки не может быть отрицательным");
            }
            this.amount = amount;
            Name = $"Фиксированная скидка {amount} руб.";

        }

        public decimal Calculate(decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException("Цена не может быть отрицательной");
            }
            decimal NewPrice = price - amount;

            if (NewPrice < 0)
            {
                NewPrice = 0;
            }
            return NewPrice;
        }
    }
}
