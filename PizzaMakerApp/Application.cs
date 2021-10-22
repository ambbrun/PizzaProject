using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PizzaMakerApp
{
    public class Application : IApplication
    {
        private readonly IPizzaAnalyzer _pizzaAnalyzer;

        public Application(IPizzaAnalyzer pizzaAnalyzer)
        {
            _pizzaAnalyzer = pizzaAnalyzer;
        }
        public void Run()
        {
            var Pizzas = _pizzaAnalyzer.GetListOfPizzas();
            var topPizzas= _pizzaAnalyzer.PizzaToppingsAnalyzer(Pizzas);
            _pizzaAnalyzer.PrintTopPizzas(topPizzas);
        }
    }
}
