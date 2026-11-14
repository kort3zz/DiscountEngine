using System;
using System.Collections.Generic;
using System.Text;

namespace NewTest
{
    public class PricingResult
    {
        public decimal BaseTotal { get; private set; }
        public List<AppliedDiscount> AppliedDiscounts { get; private set; }
        public decimal FinalTotal { get; private set; }

        public PricingResult(decimal baseTotal,
            List<AppliedDiscount> appliedDiscounts, decimal finalTotal)
        {
            BaseTotal = baseTotal;
            AppliedDiscounts = appliedDiscounts;
            FinalTotal = finalTotal;
        }
    }
}
