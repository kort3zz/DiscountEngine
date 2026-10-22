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

        public decimal ApplyDiscount(Product product, IEnumerable<IdiscountStrategy> strategies)
        {
            if (product == null)
            {
                throw new ArgumentException(nameof(product));
            }

            if (strategies == null)
            {
                throw new ArgumentException(nameof (strategies));
            }
            
            if (product.Price < 0)
            {
                throw new ArgumentException("Исходная цена не может быть отрицательной");
            }

            decimal currentPrice = product.Price;


            foreach (IdiscountStrategy strategy in strategies)
            {
                try
                {
                    decimal oldPrice = currentPrice;

                    currentPrice = strategy.Calculate(currentPrice);

                    decimal saved = oldPrice - currentPrice;

                    logger.Log($"{strategy.Name}: {oldPrice} -> {currentPrice} руб. " + $"(экономия {saved} руб.)");

                    logger.Log("Цена после скидки: " + currentPrice);
                }
                catch (ArgumentException ex)
                {
                    logger.Log($"Ошибка при применении скидки {strategy.Name}: {ex.Message}");
                }


            }
            logger.Log("Расчёт завершён. Итоговая цена: " + currentPrice + " руб.");

            return currentPrice;
        }
    }
}
