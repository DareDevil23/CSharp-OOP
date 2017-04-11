

namespace _02.VehicleExtension
{
    public class Car : Vehicle
    {
        private const double ConsumptionIncreaser = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + ConsumptionIncreaser, tankCapacity)
        {
            
        }

        public override void Refuel(double fuelLitters)
        {
            double availableSpace = this.TankCapacity - FuelQuantity;
            if (fuelLitters > availableSpace)
            {
                System.Console.WriteLine("Cannot fit fuel in tank");
                return;
            }
            this.FuelQuantity += fuelLitters;
        }
    }
}
