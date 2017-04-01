

namespace PizzaCalories
{
    abstract class Ingridient
    {
        protected const double baseCaloriesPerGram = 2;

        public abstract double CalculateCaloriesPerGram();
    }
}
