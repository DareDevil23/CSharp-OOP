using System;

namespace _03.WildFarm
{
    class Program
    {
        static Mammal mammal = null;
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int counter = 0;
            
            while (input != "End")
            {
                if (counter % 2 == 0)
                {
                    MakeMammalObjects(input);
                }
                else
                {
                    MakeFoodObjects(input);
                }
                counter++;
                input = Console.ReadLine();
            }
        }

        private static void MakeFoodObjects(string input)
        {
            string[] foodTokens = input.Split(' ');
            string foodType = foodTokens[0];
            int foodQuantity = Convert.ToInt32(foodTokens[1]);
            switch (foodType)
            {
                case "Meat": Food meat = new Meat(foodQuantity);
                    mammal.MakeSound();
                    mammal.EatFood(meat);
                    Console.WriteLine(mammal);
                    break;
                case "Vegetable": Food vegetable = new Vegetable(foodQuantity);
                    mammal.MakeSound();
                    mammal.EatFood(vegetable);
                    Console.WriteLine(mammal);
                    break;
                default:
                    break;
            }
        }

        private static void MakeMammalObjects(string input)
        {
            string[] animalTokens = input.Split(' ');
            string animalType = animalTokens[0];
            string animalName = animalTokens[1];
            double animalWeight = double.Parse(animalTokens[2]);
            string animalLivingRegion = animalTokens[3];
            switch (animalType)
            {
                case "Mouse":
                    mammal = new Mouse(animalName, animalWeight, animalLivingRegion);                
                    break;
                case "Zebra":
                    mammal = new Zebra(animalName, animalWeight, animalLivingRegion);
                    break;
                case "Cat":
                    string catBreed = animalTokens[4];
                    mammal = new Cat(animalName, animalWeight, animalLivingRegion, catBreed);
                    break;
                case "Tiger":
                    mammal = new Tiger(animalName, animalWeight, animalLivingRegion);
                    break;
                default:
                    break;
            }
        }
    }
}
