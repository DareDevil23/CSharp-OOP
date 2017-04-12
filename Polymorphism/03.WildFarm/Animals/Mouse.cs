using System;

namespace _03.WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string animalName, double animalWeight, string animalLivingRegion) 
            : base(animalName, animalWeight, animalLivingRegion)
        {
        }

        public override void EatFood(Food food)
        {
            base.EatFood(food);
            if (food.GetType().Name == "Vegetable")
            {
                Console.WriteLine("A cheese was just eaten!");
            }

        }

        public override void MakeSound()
        {
            Console.WriteLine("SQUEEEAAAK!");
        }
    }
}
