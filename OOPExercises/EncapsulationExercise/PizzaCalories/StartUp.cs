using System;
using System.Linq;

namespace PizzaCalories
{
    public  class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaInput = Console.ReadLine()
               .Split()
               .ToArray();
                var pizzaName = pizzaInput[1];

                var input = Console.ReadLine()
                    .Split()
                    .ToArray();

                var flourType = input[1];
                var bakingTechnique = input[2];
                var weight = double.Parse(input[3]);

                Dough dough = new Dough(flourType, bakingTechnique, weight);
                Pizza pizza = new Pizza(pizzaName, dough);
                var command = Console.ReadLine();
                while (command != "END")
                {
                    var toppingInput = command
                        .Split()
                        .ToArray();
                    var topingType = toppingInput[1];
                    var toppingWeight = double.Parse(toppingInput[2]);
                    Topping topping = new Topping(topingType, toppingWeight);
                    pizza.AddTopping(topping);

                    command = Console.ReadLine();

                }
                Console.WriteLine($"{pizza.Name} - {pizza.ToptalCalories:F2} Calories.");
            }   
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
