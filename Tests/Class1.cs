using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using xCarpaccio.client;

namespace Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void NUnitIsWorking()
        {
            Assert.IsTrue(true);
        }
        
        [Test]
        public void Test_de_la_TVA()
        {
            bool reponse = false;
            var unCalcul = new Calcul();
            double tva = unCalcul.getTVA("DE");
            if (tva == 1.20)
            {
                reponse = true;
            }

            Assert.IsTrue(reponse);
        }

        [Test]
        public void Test_du_total_hors_taxes()
        {
            bool reponse = false;
            var order = new Order();
            double[] prices = {13.56, 9.8, 10.86};
            double[] quantities = {10, 9, 2};
            double unTotal = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                unTotal = unTotal + (Convert.ToDouble(prices[i]) * quantities[i]);
            }

            if (unTotal == 245.52)
            {
                reponse = true;
            }

            Assert.IsTrue(reponse);
        }
    }
}
