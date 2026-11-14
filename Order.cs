using System;
using System.Collections.Generic;
using System.Text;

namespace NewTest
{
    public class Order
    {
        public Customer Customer { get; private set; }
        public List<CartItem> Items { get; private set; }
        public string PromoCode { get; private set; }
        public DateTime OrderDate { get; private set; }
        public decimal DeliveryCost { get; private set; }

        public Order(Customer customer, List<CartItem> items, decimal deliveryCost, string  promoCode = "")
        {
            Customer = customer;
            Items = items;
            DeliveryCost = deliveryCost;
            PromoCode = promoCode;
            OrderDate = DateTime.Now;
        }
    }
}
