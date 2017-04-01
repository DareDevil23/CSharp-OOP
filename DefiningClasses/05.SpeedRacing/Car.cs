
namespace _05.SpeedRacing
{
    class Car
    {
        public Car(string model, double fuelAmount, double fuelCost, double distanceTravelled)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelCost = fuelCost;
            this.DistanceTravelled = distanceTravelled;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelCost { get; set; }
        public double DistanceTravelled { get; set; }

        public bool CanCarMove(double amountKm)
        {
            bool canMove = false;
            if (amountKm * this.FuelCost <= this.FuelAmount)
            {
                canMove = true;
                var usedFuel = amountKm * this.FuelCost;
                this.FuelAmount -= usedFuel;
                this.DistanceTravelled += amountKm;
            }

            return canMove;
        }
    }
}
