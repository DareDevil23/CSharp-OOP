using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    class Pizza
    {
        private string name;
        private int toppingsAmount;
        private List<Topping> toppings = new List<Topping>();

        public Pizza(string name, int toppingsAmount)
        {
            this.Name = name;
            this.ToppingsAmount = toppingsAmount;
        }

        public Pizza()
        {
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentOutOfRangeException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough PizzaDough { get; set; }

        public int ToppingsAmount
        {
            get { return this.toppingsAmount; }
            private set
            {
                if (value > 10 || value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number of toppings should be in range [0..10].");
                }
                this.toppingsAmount = value;
            }
        }

        public void AddToppings(Topping topping)
        {
            toppings.Add(topping);
        }

        public double Calories { get { return CalculatePizzaCalories(); } }

        private double CalculatePizzaCalories()
        {
            double toppingsSumCalories = 0d;
            foreach (Topping topping in toppings)
            {
                toppingsSumCalories += topping.CalculateCaloriesPerGram();
            }
            return PizzaDough.CalculateCaloriesPerGram() + toppingsSumCalories;
           
        }

    }
}
