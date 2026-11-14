using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System;
using System.Collections.Generic;

namespace NewTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаём покупателя
            Customer customer = new Customer("Иван", false, DateTime.Now.AddDays(-15));

            // Создаём товары
            Product keyboard = new Product("Клавиатура", 3000, 1, "Периферия");
            Product mouse = new Product("Мышь", 1500, 2, "Периферия");

            // Создаём корзину
            List<CartItem> items = new List<CartItem>
            {
                new CartItem(keyboard, 2),
                new CartItem(mouse, 1)
            };

            // Создаём заказ
            Order order = new Order(customer, items, 300, "SALE10");

            // Создаём стратегии скидок
            List<IdiscountStrategy> strategies = new List<IdiscountStrategy>
            {
                new ThreeForTwoDiscount(),
                new PercentageDiscount(10),
                new FixedDiscount(500),
                new FirstOrderDiscount(),
                new LoyaltyDiscount()
            };

            // Создаём журнал
            ILogger logger = new FileLogger("discount-log.txt");

            // Создаём движок скидок
            DiscountEngine engine = new DiscountEngine(logger);

            // Рассчитываем стоимость заказа
            PricingResult result = engine.ApplyDiscount(order, strategies);

            // Выводим результат
            Console.WriteLine("Стоимость без скидок: " + result.BaseTotal + " руб.");

            Console.WriteLine("\nПрименённые скидки:");

            foreach (AppliedDiscount discount in result.AppliedDiscounts)
            {
                Console.WriteLine(
                    discount.Name + " — экономия " + discount.SavedAmount + " руб."
                );
            }

            Console.WriteLine("\nИтоговая стоимость: " + result.FinalTotal + " руб.");

            Console.ReadKey();
        }
    }
}