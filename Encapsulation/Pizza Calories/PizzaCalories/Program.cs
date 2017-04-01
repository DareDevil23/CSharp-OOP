using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {           
            Pizza pizza = null;
            Dough dough = null;
            Topping topping = null;
            try
            {
                string input = Console.ReadLine();               
                while (input != "END")
                {
                    string[] tokens = input.Split(' ');
                    if (tokens[0] == "Pizza")
                    {
                        string pizzaName = tokens[1];
                        int toppingsCount = int.Parse(tokens[2]);
                        pizza = new Pizza(pizzaName, toppingsCount);
                    }
                    else if (tokens[0] == "Dough")
                    {
                        string flouerType = tokens[1];
                        string bakingTechnique = tokens[2];
                        double weight = double.Parse(tokens[3]);
                        dough = new Dough(flouerType, bakingTechnique, weight);
                        if (pizza == null)
                        {
                            pizza = new Pizza();
                        }
                        pizza.PizzaDough = dough;
                    }
                    else if (tokens[0] == "Topping")
                    {
                        string toppingType = tokens[1];
                        int weight = int.Parse(tokens[2]);
                        topping = new Topping(toppingType, weight);
                        if (pizza == null)
                        {
                            pizza = new Pizza();
                        }
                        pizza.AddToppings(topping);
                    }
                    input = Console.ReadLine();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.ParamName);
                return;
            }
            catch (ArgumentException ex)
            {   
                Console.WriteLine(ex.Message);
                return;
            }

            if (string.IsNullOrEmpty(pizza.Name))
            {
                if (dough != null)
                {
                    Console.WriteLine($"{dough.CalculateCaloriesPerGram():F2}");
                }
                if (topping != null)
                {
                    Console.WriteLine($"{topping.CalculateCaloriesPerGram():F2}");
                }
                return;
            }        
           Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");           
        }
    }
}
