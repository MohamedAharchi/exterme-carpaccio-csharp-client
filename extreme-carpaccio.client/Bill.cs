using System;

namespace xCarpaccio.client
{
    class Bill
    {
        public decimal total { get; set; }

        

        public void calculTVA(decimal unTotal, double tva)
        {
            double leTotal;
            leTotal = Convert.ToDouble(unTotal) *tva;
            this.total = Math.Round(Convert.ToDecimal(leTotal), 2);

        }
    }
}
