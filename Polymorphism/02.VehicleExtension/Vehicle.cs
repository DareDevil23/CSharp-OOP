using System;

namespace _02.VehicleExtension
{
    public abstract class Vehicle
    {
        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity) 
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
           
        }

        public double TankCapacity { get; set; }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Fuel must be a positive number");
                }
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumption { get; set; }

        public double Distance { get; set; }

        public abstract void Refuel(double fuelLitters);

        public void Drive()
        {
            double fuelNeed = this.Distance * this.FuelConsumption;
            bool canDrive =  fuelNeed <= this.FuelQuantity;
            if (canDrive)
            {
                this.FuelQuantity -= fuelNeed;
                Console.WriteLine($"{this.GetType().Name} travelled {this.Distance} km");
            }
            else
            {                
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
            
        }

        public override string ToString()
        {
            return string.Format($"{this.GetType().Name}: {this.FuelQuantity:F2}");
        }
    }
}
