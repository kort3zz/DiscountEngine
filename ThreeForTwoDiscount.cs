using System;
using System.Collections.Generic;
using System.Text;

namespace NewTest
{
    public class ThreeForTwoDiscount : IdiscountStrategy
    {
        public string Name { get; }

        public ThreeForTwoDiscount()
        {
            Name = "Акция 3 по цене 2";
        }

        public decimal Calculate(DiscountContext context)
        {
            Dictionary<string, List<decimal>> categories =
                new Dictionary<string, List<decimal>>();

            // Собираем товары по категориям
            foreach (CartItem item in context.Order.Items)
            {
                string category = item.Product.Category;

                if (!categories.ContainsKey(category))
                {
                    categories[category] = new List<decimal>();
                }

                for (int i = 0; i < item.Quantity; i++)
                {
                    categories[category].Add(item.Product.BasePrice);
                }
            }

            decimal totalDiscount = 0;

            // Рассчитываем бесплатные товары
            foreach (KeyValuePair<string, List<decimal>> category in categories)
            {
                List<decimal> prices = category.Value;

                prices.Sort();
                prices.Reverse();

                for (int i = 2; i < prices.Count; i += 3)
                {
                    totalDiscount += prices[i];
                }
            }

            return context.CurrentTotal - totalDiscount;
        }
    }
}
