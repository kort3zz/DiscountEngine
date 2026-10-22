using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTest
{
    class PercentageDiscount : IdiscountStrategy
    {
        public string Name { get; }
        public int Percent { get; private set; }

        public PercentageDiscount(int percent)
        {
            if (percent < 0 || percent > 100)
            {
                throw new ArgumentException("Процент скидки должен быть от 0 до 100");
            }
            Percent = percent;
            Name = $"Скидка {percent}%";
        }

        public decimal Calculate(decimal price)
        {
            return price - (price * Percent / 100);
        }

    }
}
