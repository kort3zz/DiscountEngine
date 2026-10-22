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

namespace NewTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IdiscountStrategy> strategies = new List<IdiscountStrategy>();

            strategies.Add(DiscountFactory.CreatePercentage(20));

            strategies.Add(DiscountFactory.CreateFixed(150));

            strategies.Add(DiscountFactory.CreateCustomer(100));

            Product product = new Product ("noutbuk", 1000);

            ILogger logger1 = new FileLogger("Discount-log.txt");

            ILogger logger2 = DiscountLogger.Instance;

            DiscountEngine engine1 = new DiscountEngine(logger2);

            DiscountEngine engine2 = new DiscountEngine(logger1);

            decimal result = engine1.ApplyDiscount(product, strategies);

            decimal result2 = engine2.ApplyDiscount(product, strategies);

            product.ChangePrice(result);

            Console.WriteLine(result);
            Console.WriteLine();
        }
    }
}
