﻿using System.IO;
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
                Bill bill = new Bill();
                Calcul unCalcul = new Calcul();
                double unTotal = 0;
                double unTotalTtc = 0;
                double totalHt = 0;
                double tva = 0;
                
                totalHt = unCalcul.calculTotalHT(order.Prices, order.Quantities);
                tva = unCalcul.getTVA(order.Country);
                unTotalTtc = totalHt * tva;
                unTotal = unCalcul.getTotalAvecReduction(unTotalTtc);

                bill.total = Math.Round(Convert.ToDecimal(unTotal), 2);

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