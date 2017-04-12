using System;

namespace _03.WildFarm
{
    public class Zebra : Mammal
    {
        public Zebra(string animalName, double animalWeight, string animalLivingRegion) 
            : base(animalName, animalWeight, animalLivingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Zs");
        }
    }
}
