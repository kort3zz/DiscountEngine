using System;
using System.Collections.Generic;
using System.Text;

namespace NewTest
{
    public class CartItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal GetTotalPrice()
        {
            return Product.Price * Quantity;
        }
    }
}
