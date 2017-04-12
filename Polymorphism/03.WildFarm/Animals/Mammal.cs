using System;

namespace _03.WildFarm
{
    public abstract class Mammal : Animal
    {
        public Mammal(string animalName, double animalWeight, string animalLivingRegion)
        {
            this.AnimalName = animalName;
            this.AnimalWeight = animalWeight;
            this.LivingRegion = animalLivingRegion;
        }

        public string LivingRegion { get; set; }      

        public override void EatFood(Food food)
        {
            if (food.GetType().Name != "Vegetable")
            {
                string animal = this.GetType().Name;
                if (animal == "Mouse")
                {
                    animal = "Mice";
                }
                else
                {
                    animal = "Zebras";
                }
                Console.WriteLine($"{animal} are not eating that type of food!");
                return;
            }
            else
            {
                this.FoodEaten += food.Quantity;
            }
            
        }

        public override string ToString()
        {
            return string.Format($"{this.GetType().Name}[{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]");
        }
    }
}
