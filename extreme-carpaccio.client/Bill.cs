using System;

namespace xCarpaccio.client
{
    class Bill
    {
        public decimal total { get; set; }

        public void calculTotal(decimal[] prices, int[] quantities)
        {
            decimal unTotal = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                unTotal = unTotal + Convert.ToDecimal((prices[i]*quantities[i]));
            }

            this.total = unTotal;
        }
    }
}
