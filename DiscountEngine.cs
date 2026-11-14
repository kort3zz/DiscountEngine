using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTest
{
    class DiscountEngine
    {
        private ILogger logger;

        public DiscountEngine(ILogger logger)
        {
            this.logger = logger;
        }

        public PricingResult ApplyDiscount(Order order, IEnumerable<IdiscountStrategy> strategies)
        {
            if (order == null)
            {
                throw new ArgumentException(nameof(order));
            }

            if (strategies == null)
            {
                throw new ArgumentException(nameof (strategies));
            }

            decimal baseTotal = 0;

            foreach (CartItem item in order.Items)
            {
                baseTotal += item.GetTotalPrice();
            }

            baseTotal += order.DeliveryCost;

            baseTotal = Math.Round(baseTotal, 2, MidpointRounding.ToEven);

            DiscountContext context = new DiscountContext(order, baseTotal);

            List<AppliedDiscount> appliedDiscounts = new List<AppliedDiscount>();

            foreach (IdiscountStrategy strategy in strategies)
            {
                try
                {
                    decimal oldPrice = context.CurrentTotal;

                    decimal newPrice = strategy.Calculate(context);

                    if (newPrice < 0)
                    {
                        newPrice = 0;
                    }

                    newPrice = Math.Round(newPrice, 2, MidpointRounding.ToEven);

                    decimal saved = oldPrice - newPrice;

                    if (saved > 0)
                    {
                        AppliedDiscount discount = new AppliedDiscount(strategy.Name, saved, "Скидка успешно применена");

                        appliedDiscounts.Add(discount);
                    }

                    context.CurrentTotal = newPrice;

                    logger.Log($"{strategy.Name}: {oldPrice} -> {newPrice} руб. " + $"(экономия {saved} руб.)");

                }
                catch (ArgumentException ex)
                {
                    logger.Log($"Ошибка при применении скидки {strategy.Name}: {ex.Message}");
                }
            }
            decimal finalTotal = context.CurrentTotal;

            logger.Log("Расчёт завершён. Итоговая цена: " + finalTotal + " руб.");

            return new PricingResult(baseTotal, appliedDiscounts, finalTotal);
        }
    }
}
