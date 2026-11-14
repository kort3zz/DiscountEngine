using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTest
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Category { get; private set; }
        public decimal BasePrice { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, decimal price, int id = 0, string category = "Без категории")
        {
            Name = name;
            Price = price;
            BasePrice = price;
            Id = id;
            Category = category;
        }

        public void Print()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Название: {Name}");
            Console.WriteLine($"Категория: {Category}");
            Console.WriteLine($"Базовая цена: {BasePrice}");
            Console.WriteLine($"Текущая цена: {Price}");
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
