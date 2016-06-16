using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xCarpaccio.client
{
    public class Calcul
    {
        private static string[] countries = {"DE", "UK", "FR", "IT", "ES", "PL", "RO", "NL", "BE", "EL", "CZ", "PT", "HU", "SE", "AT", "BG", "DK", "FI", "SK", "IE", "HR", "LT", "SI", "LV", "EE", "CY", "LU", "MT"};

        private static double[] tva =
        {
            1.20, 1.21, 1.20, 1.25, 1.19, 1.21, 1.20, 1.20, 1.24, 1.20, 1.19, 1.23, 1.27,
            1.23, 1.22, 1.21, 1.21, 1.17, 1.18, 1.21, 1.23, 1.23, 1.24, 1.20, 1.22, 1.21, 1.25, 1.20
        };
        public Calcul()
        {
            
        }

        public double calculTotalHT(decimal[] prices, int[] quantities)
        {
            double unTotal = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                unTotal = unTotal + (Convert.ToDouble(prices[i]) * quantities[i]);
            }

            return unTotal;
        }

        public double getTVA(string countrie)
        {
            double uneTva = 0;
            for (int i = 0; i < countries.Length; i++)
            {
                if (countries[i] == countrie)
                {
                    uneTva = tva[i];
                }
            }
            return uneTva;
        }

        public double getTotalAvecReduction(double unTotal)
        {
            if (unTotal >= 1000 && unTotal < 5000)
            {
                unTotal = unTotal - (unTotal * 0.03);
            }

            else if (unTotal >= 5000 && unTotal < 7000)
            {
                unTotal = unTotal - (unTotal * 0.05);
            }

            else if (unTotal >= 7000 && unTotal < 10000)
            {
                unTotal = unTotal - (unTotal * 0.07);
            }

            else if (unTotal >= 10000 && unTotal < 50000)
            {
                unTotal = unTotal - (unTotal * 0.10);
            }

            else if (unTotal >= 50000)
            {
                unTotal = unTotal - (unTotal * 0.15);
            }

            return unTotal;
        }

    }
}
