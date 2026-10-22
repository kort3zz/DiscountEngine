using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTest
{
    class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;

        }

        public void Print()
        {
            Console.WriteLine(Name);
            Console.WriteLine(Price);

        }

        public void ChangePrice(decimal newPrice)
        {
            if (newPrice >= 0)
            {
                Price = newPrice;
            }
        }
    }
}
