

namespace _02.VehicleExtension
{
    class Truck : Vehicle
    {
        private const double ConsumptionIncreaser = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + ConsumptionIncreaser, tankCapacity)
        {
        }

        public override void Refuel(double fuelLitters)
        {
            this.FuelQuantity += (0.95 * fuelLitters); 
        }
    }
}
