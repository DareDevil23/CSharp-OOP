using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dough dough = new Dough("White", "Chewy", 100);
            //Console.WriteLine(dough.CalculateCaloriesPerGram());
            //Topping topping = new Topping("Meat", 30);
            //Console.WriteLine("{0:F2}", topping.CalculateCaloriesPerGram());

            Pizza pizza = null;
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
                        Dough dough = new Dough(flouerType, bakingTechnique, weight);
                        pizza.PizzaDough = dough;
                    }
                    else if (tokens[0] == "Topping")
                    {
                        string toppingType = tokens[1];
                        int weight = int.Parse(tokens[2]);
                        Topping topping = new Topping(toppingType, weight);
                        pizza.AddToppings(topping);
                    }
                    input = Console.ReadLine();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }           

            Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");
        }
    }
}
