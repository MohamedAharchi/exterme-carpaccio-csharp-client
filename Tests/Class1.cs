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
    }
}
