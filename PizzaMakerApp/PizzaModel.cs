using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaMakerApp
{
    public class PizzaModel : IPizzaModel
    {
        public List<string> Toppings { get; set; }
    }
}
