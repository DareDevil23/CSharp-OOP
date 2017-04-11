
namespace _02.VehicleExtension
{
    public class Bus : Vehicle
    {
        private const double ConsumptionIncreaser = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity, bool hasPessanger) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.HasPessangers = hasPessanger;
        }

        public bool HasPessangers { get; set; }

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

        public void FuelConsumptionWitAirConditionerSetter()
        {
            if (this.HasPessangers == true)
            {
                this.FuelConsumption += 1.4;
            }
        }
    }
}
