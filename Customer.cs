using System;
using System.Collections.Generic;
using System.Text;

namespace NewTest
{
    public class Customer
    {
        public string Name { get; private set; }
        public DateTime? LastPurchaseDate { get; private set; }
        public bool IsFirstOrder { get; private set; }

        public Customer(string name, bool isFirstOrder, DateTime? lastPurchaseDate = null)
        {
            Name = name;
            LastPurchaseDate = lastPurchaseDate;
            IsFirstOrder = isFirstOrder;
        }
    }
}
