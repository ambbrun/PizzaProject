using System.Collections.Generic;

namespace PizzaMakerApp
{
    public interface IPizzaModel
    {
        List<string> Toppings { get; set; }
    }
}