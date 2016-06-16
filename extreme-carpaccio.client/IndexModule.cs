using System.IO;
using System.Text;
using System.Xml.Schema;

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
                double total = 0;
                if (order.Country == "DE")
                {
                    
                    bill.calculTotal(order.Prices, order.Quantities);
                    total = Convert.ToDouble(bill.total)*1.20;
                    if (total >= 50000)
                    {
                        total = total*0.15;
                    }

                    else if (total >= 10000 && total < 50000)
                    {
                        total = total*0.10;
                    }

                    else if (total >= 7000 && total < 10000)
                    {
                        total = total*0.7;
                    }

                    else if (total >= 5000 && total < 7000)
                    {
                        total = total*0.5;
                    }

                    else if (total >= 3000 && total < 5000)
                    {
                        total = total*0.3;

                    }
                    else
                    {
                        total = -1;
                    }

                    bill.total = Convert.ToDecimal(total);
                }
                /*bill.calculTotal(order.Prices, order.Quantities);
                Calcul unCalcul = new Calcul();
                //double tva = unCalcul.getTVA();*/
                //TODO: do something with order and return a bill if possible
                // If you manage to get the result, return a Bill object (JSON serialization is done automagically)
                // Else return a HTTP 404 error : return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
                if (total == -1)
                {
                    return Negotiate.WithStatusCode(HttpStatusCode.NotFound);
                }

                else
                {
                    return bill;
                }
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