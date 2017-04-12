using System;

namespace _03.WildFarm
{
    public class Cat : Feline
    {
        public Cat(string animalType, double animalWeight, string animalLivingRegion, string breed) 
            : base(animalType, animalWeight, animalLivingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; set; }

        public override void EatFood(Food food)
        {
            this.FoodEaten += food.Quantity;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meowwww");
        }

        public override string ToString()
        {
            return string.Format($"{this.GetType().Name}[{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]");
        }
    }
}
