using System;
using System.Collections.Generic;
using System.Text;


namespace NewTest
{
    public class AppliedDiscount
    {
        public string Name { get; private set; }
        public decimal SavedAmount { get; private set; }
        public string Reason { get; private set; }

        public AppliedDiscount(string name, decimal savedAmount, string reason)
        {
            Name = name;
            SavedAmount = savedAmount;
            Reason = reason;
        }
    }
}

