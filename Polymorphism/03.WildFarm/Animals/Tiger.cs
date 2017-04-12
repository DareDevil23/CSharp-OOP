using System;

namespace _03.WildFarm
{
    public class Tiger : Feline
    {
        public Tiger(string animalName, double animalWeight, string animalLivingRegion) 
            : base(animalName, animalWeight, animalLivingRegion)
        {
        }

        public override void EatFood(Food food)
        {
            if (food.GetType().Name == "Vegetable")
            {
                Console.WriteLine($"Tigers are not eating that type of food!");
                return;
            }
            this.FoodEaten += food.Quantity;
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROAAR!!!");
        }
    }
}
