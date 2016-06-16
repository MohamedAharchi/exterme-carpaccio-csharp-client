using System.IO;
using System.Text;

namespace xCarpaccio.client
{
    using Nancy;
    using System;
    using Nancy.ModelBinding;

    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => "It works !!! You need to register your server on main server.";

            Post["/order"] = _ =>
            {
                using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    Console.WriteLine("Order received: {0}", reader.ReadToEnd());
                }

                var order = this.Bind<Order>();
                Bill bill = null;
                if (order.Country == "DE" || order.Country == "FR" || order.Country == "RO" || order.Country == "NL" || order.Country == "LV") 
                {
                    Bill unBill = new Bill();
                    bill = unBill;
                    double unTotal = 0;
                    for (int i = 0; i < order.Prices.Length; i++)
                    {
                        unTotal = unTotal + (Convert.ToDouble(order.Prices[i]) * order.Quantities[i]);
                    }

                    unTotal = unTotal * 1.20;

                    if (unTotal >= 1000 && unTotal < 5000)
                    {
                        unTotal = unTotal - (unTotal*0.03);
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
                    bill.total = Math.Round(Convert.ToDecimal(unTotal), 2);

                }


                /*bill.calculTotal(order.Prices, order.Quantities);
                Calcul unCalcul = new Calcul();
                //double tva = unCalcul.getTVA();*/
                //TODO: do something with order and return a bill if possible
                // If you manage to get the result, return a Bill object (JSON serialization is done automagically)
                // Else return a HTTP 404 error : return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
                
                return bill;
            };

            Post["/feedback"] = _ =>
            {
                var feedback = this.Bind<Feedback>();
                Console.Write("Type: {0}: ", feedback.Type);
                Console.WriteLine(feedback.Content);
                return Negotiate.WithStatusCode(HttpStatusCode.OK);
            };
        }
    }
}