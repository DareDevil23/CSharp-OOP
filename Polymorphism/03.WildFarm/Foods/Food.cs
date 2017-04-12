
namespace _03.WildFarm
{
    public abstract class Food
    {
        public Food(int foodQuantity)
        {
            this.Quantity = foodQuantity;           
        }

        public int Quantity { get; set; }

    }
}
