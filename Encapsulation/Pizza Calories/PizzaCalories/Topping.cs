using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    class Topping : Ingridient
    {
        private readonly string[] typesArray = { "meat", "veggies", "cheese", "sauce" };
        private readonly Dictionary<string, double> modifiersCalories = new Dictionary<string, double>
        {
            {"meat" , 1.2 },
            {"veggies", 0.8},
            {"cheese", 1.1},
            {"sauce", 0.9}
        };
        private const double minWeight = 1;
        private const double MaxWeight = 50;

        private string type;
        private double weight;

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get { return this.type; }
            private set
            {
                if (!typesArray.Contains(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < minWeight || value > MaxWeight)
                {
                    throw new ArgumentOutOfRangeException($"{this.Type} should be in range [1..50]");
                }
                this.weight = value;
            }
        }

        public override double CalculateCaloriesPerGram()
        {
            return baseCaloriesPerGram * modifiersCalories[this.Type.ToLower()] * this.Weight;
        }
    }
}
