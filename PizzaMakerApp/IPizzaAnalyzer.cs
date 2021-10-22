using System.Collections.Generic;

namespace PizzaMakerApp
{
    public interface IPizzaAnalyzer
    {
        List<IPizzaModel> GetListOfPizzas();
        List<(string, int)> PizzaToppingsAnalyzer(List<IPizzaModel> pizzas);
        void PrintTopPizzas(List<(string, int)> topPizzas);
    }
}