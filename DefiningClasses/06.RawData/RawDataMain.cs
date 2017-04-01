using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.RawData
{
    class RawDataMain
    {
        public static List<Car> cars; 

        static void Main(string[] args)
        {
            GetCarsDataInfo();
            ExecuteCommandForPrintingSpecificCars();
        }

        private static void ExecuteCommandForPrintingSpecificCars()
        {
            string command = Console.ReadLine();
            if (command == "fragile")  //print all cars whose Cargo Type is “fragile” with a tire whose pressure is  < 1
            {
                foreach (Car car in cars.Where( c => c.Cargo.Type == "fragile").Where(cT => cT.Tires.Any(t => t.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }                                        

            }
            else if(command == "flamable") //print all cars whose Cargo Type is “flamable” and have Engine Power > 250
            {
                foreach (Car car in cars.Where(c => c.Cargo.Type == "flamable").Where(e => e.Engine.Power > 250))
                {
                    Console.WriteLine($"{car.Model}");
                }
            }
        }

        private static void GetCarsDataInfo()
        {
            cars = new List<Car>();
            int amountCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < amountCars; i++)
            {
                string info = Console.ReadLine(); //“<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> <Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>
                string[] tokens = info.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];

                double firsTirePressure = double.Parse(tokens[5]);
                int firstTireAge = int.Parse(tokens[6]);
                double secondTirePressure = double.Parse(tokens[7]);
                int secondTireAge = int.Parse(tokens[8]);
                double thirdTirePressure = double.Parse(tokens[9]);
                int thirdTireAge = int.Parse(tokens[10]);
                double fourthTirePressure = double.Parse(tokens[11]);
                int fourthTireAge = int.Parse(tokens[12]);

                Tire[] tires =
                {
                    new Tire(firsTirePressure, firstTireAge),
                    new Tire(secondTirePressure, secondTireAge),
                    new Tire(thirdTirePressure, thirdTireAge),
                    new Tire(fourthTirePressure, fourthTireAge)
                };
                Cargo cargo = new Cargo(cargoType, cargoWeight);
                Engine engine = new Engine(engineSpeed, enginePower);
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }
        }
    }

}
