using System;

namespace xCarpaccio.client
{
    class Bill
    {
        public decimal total { get; set; }

        public void calculTotal(decimal[] prices, int[] quantities)
        {
            double unTotal = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                unTotal = unTotal + (Convert.ToDouble(prices[i])*quantities[i]);
            }

            this.total = Math.Round(Convert.ToDecimal(unTotal), 2);
        }

        public void calculTVA(decimal unTotal, double tva)
        {
            double leTotal;
            leTotal = Convert.ToDouble(unTotal) *tva;
            this.total = Math.Round(Convert.ToDecimal(leTotal), 2);

        }
    }
}
