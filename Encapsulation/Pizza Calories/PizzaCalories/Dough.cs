using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    class Dough : Ingridient
    {
        private const double MinWeight = 1;
        private const double MaxWeight = 200;

        private readonly Dictionary<string, double> modifiersCalories = new Dictionary<string, double> 
        {
            { "white", 1.5},
            { "wholegrain", 1.0},
            { "crispy",  0.9 },
            {"chewy", 1.1},
            { "homemade", 1.0 }
        };

        private string flouerType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flouerType, string bakingTechnique, double weight)
        {
            this.FlouerType = flouerType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlouerType
        {
            get { return this.flouerType; }
            private set
            {
                var flouerModifiers = modifiersCalories.Take(2).ToDictionary(x => x.Key, x => x.Value);
                if (!flouerModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flouerType = value;
            }
        }

        public string BakingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                var bakingModifiers = modifiersCalories.Skip(2).Take(3).ToDictionary(x => x.Key, x => x.Value);
                if (!bakingModifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentOutOfRangeException("Dough weight should be in range [1..200]");
                }
                this.weight = value;
            }
        }

        public override double CalculateCaloriesPerGram()
        {
            return  baseCaloriesPerGram * this.Weight * modifiersCalories[this.FlouerType.ToLower()] * modifiersCalories[this.BakingTechnique.ToLower()];
        }
    }
}
