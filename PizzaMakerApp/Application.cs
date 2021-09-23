using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PizzaMakerApp
{
    public class Application
    {
        public void Run()
        {
            List<PizzaModel> Pizzas = GetListOfPizzas();
            var topPizzas= PizzaAnalyzer(Pizzas);
            PrintTopPizzas(topPizzas);
        }

        private List<PizzaModel> GetListOfPizzas()
        {

            var pizzas = new List<PizzaModel>();
            string URL = "https://www.brightway.com/CodeTests/pizzas.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.ContentType = "application/json; charset=utf-8";
            request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("username:password"));
            request.PreAuthenticate = true;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                string pizzaData = reader.ReadToEnd();

                pizzas = (List<PizzaModel>)JsonConvert.DeserializeObject(pizzaData, typeof(List<PizzaModel>));
            }

            return pizzas;
        }

        private List<(string, int)> PizzaAnalyzer(List<PizzaModel> pizzas)
        {
            var pizzaCounts = pizzas.Select(p => new { Toppings = string.Join(", ", p.Toppings.OrderBy(t => t)) })
                                    .GroupBy(x=>x.Toppings)
                                    .OrderByDescending(x=>x.Count())
                                    .Select(x=> (x.Key, x.Count())).Take(20).ToList();

            return pizzaCounts;
        }

        private void PrintTopPizzas(List<(string, int)> topPizzas)
        {
            foreach ((string, int) t in topPizzas)
                Console.WriteLine($"{t.Item1} {t.Item2}");
        }

    }
}
