using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SpeedRacing
{
    
    class SpeedRacingMain
    {
        public static List<Car> cars;

        static void Main(string[] args)
        {
            GetCarInfo();
            ExecuteCarMoveCommands();
            PrintCarsFuelAndTravelledDistance();
        }

        private static void GetCarInfo()
        {
            cars = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCars; i++)
            {
                string info = Console.ReadLine();                  //“<Model> <FuelAmount> <FuelCostFor1km>
                string[] infoArgs = info.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string carModel = infoArgs[0];
                if (cars.Count > 0)
                {
                    if (cars.Any(c => c.Model == carModel))
                    {
                        info = Console.ReadLine();
                        continue;
                    }
                }
                double fuelAmount = double.Parse(infoArgs[1]);
                double fuelCost = double.Parse(infoArgs[2]);
                double distance = 0d;
                Car car = new Car(carModel, fuelAmount, fuelCost, distance);
                cars.Add(car);
            }
        }

        private static void ExecuteCarMoveCommands()
        {
            string command = Console.ReadLine();    //<Model> <fuelAmount>  <distanceTraveled> 
            while (!command.Equals("End"))
            {
                string[] commandArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string carModel = commandArgs[1].Trim();
                double amountKm = double.Parse(commandArgs[2]);
                Car currentCar = cars.First(c => c.Model == carModel);          
                bool canMove = currentCar.CanCarMove(amountKm);
                if (!canMove)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                command = Console.ReadLine();
            }
        }

        private static void PrintCarsFuelAndTravelledDistance()
        {
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.DistanceTravelled}");
            }
        }
    }

}
