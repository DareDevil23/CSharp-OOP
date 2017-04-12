
namespace _03.WildFarm
{
    public abstract class Animal
    {       
        public string AnimalName { get; set; }

        public string AnimalType { get; set; }

        public double AnimalWeight { get; set; }

        public int FoodEaten { get; set; }

        public abstract void MakeSound();

        public abstract void EatFood(Food food);
             
    }
}
