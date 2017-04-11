using System;

namespace _02.VehicleExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split(' ');
            double carFuelQuantity = double.Parse(carTokens[1]);
            double carFuelConsumption = double.Parse(carTokens[2]);
            double carTankCapacity = double.Parse(carTokens[3]);

            Vehicle car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);

            string[] truckTokens = Console.ReadLine().Split(' ');
            double truckFuelQuantity = double.Parse(truckTokens[1]);
            double truckFuelConsumption = double.Parse(truckTokens[2]);
            double truckTankCapacity = double.Parse(truckTokens[3]);

            Vehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);

            string[] busTokens = Console.ReadLine().Split(' ');
            double busFuelQuantity = double.Parse(busTokens[1]);
            double busFuelConsumption = double.Parse(busTokens[2]);
            double busTankCapacity = double.Parse(busTokens[3]);

            Vehicle bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity, false);

            Vehicle[] vehicles = new Vehicle[] {car, truck, bus};
        
            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(' ');
                string command = commandArgs[0];
                string vehicleType = commandArgs[1];
                double driveDistance = 0;
                double litersToRefuel = 0;
                
                if (command ==  "Drive" || command == "DriveEmpty")
                {
                    driveDistance = double.Parse(commandArgs[2]);
                }
                else if(command == "Refuel")
                {
                    litersToRefuel = double.Parse(commandArgs[2]);
                }

                switch (vehicleType)
                {
                    case "Car":
                        if (command == "Drive")
                        {
                            car.Distance = driveDistance;
                            car.Drive();
                        }
                        else if (command == "Refuel")
                        {
                            car.Refuel(litersToRefuel);
                        }
                        break;
                    case "Truck":
                        if (command == "Drive")
                        {
                            truck.Distance = driveDistance;
                            truck.Drive();
                        }
                        else if (command == "Refuel")
                        {
                            truck.Refuel(litersToRefuel);
                        }
                        break;
                       
                    case "Bus":
                        if (command == "Drive")
                        {
                            Bus casted = bus as Bus;
                            
                            casted.HasPessangers = true;
                            casted.FuelConsumptionWitAirConditionerSetter();
                            bus.Distance = driveDistance;
                            casted.Drive();
                        }
                        else if (command == "DriveEmpty")
                        {
                            bus.Distance = driveDistance;
                            bus.Drive();
                        }
                        else if (command == "Refuel")
                        {
                            bus.Refuel(litersToRefuel);
                        }
                        break;
                    default:
                        break;
                }

               
            }

            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
