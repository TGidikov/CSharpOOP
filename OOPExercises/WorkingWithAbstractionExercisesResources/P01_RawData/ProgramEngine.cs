using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_RawData
{
    public class ProgramEngine
    {
        private readonly List<Car> cars;
        private readonly List<Tire> carTires;

        public ProgramEngine()
        {
            this.cars = new List<Car>();
            this.carTires = new List<Tire>();
        }
        public void Run ()
        {

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries).ToArray() ;
                string model = parameters[0];
                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);
                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];
                double tire1Pressure = double.Parse(parameters[5]);
                int tire1age = int.Parse(parameters[6]);
                double tire2Pressure = double.Parse(parameters[7]);
                int tire2age = int.Parse(parameters[8]);
                double tire3Pressure = double.Parse(parameters[9]);
                int tire3age = int.Parse(parameters[10]);
                double tire4Pressure = double.Parse(parameters[11]);
                int tire4age = int.Parse(parameters[12]);
                Engine engine = CreateEngine(engineSpeed, enginePower);
                Cargo cargo = CreateCargo(cargoWeight, cargoType);
                List<Tire> tires = new List<Tire>();
                this.carTires.Add(CreateTire(tire1age, tire1Pressure));
                this.carTires.Add(CreateTire(tire2age, tire2Pressure));
                this.carTires.Add(CreateTire(tire3age, tire3Pressure));
                this.carTires.Add(CreateTire(tire4age, tire4Pressure));
                Car car = CreateCar(model, engine, cargo, carTires);
                this.cars.Add(car);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                    .Select(c =>c.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }






        }
        private Engine CreateEngine(int speed,int power)
        {
            Engine engine = new Engine(speed, power);
                return engine;
        }
        private Cargo CreateCargo(int weight,string type)
        {
            Cargo cargo = new Cargo(weight, type);
            return cargo;
        }
        private Tire CreateTire(int age,double pressure)
        {
            Tire tire = new Tire(age, pressure);
            return tire;
        }
        private Car CreateCar(string model,Engine engine,Cargo cargo,List<Tire> tires)
        {
            Car car = new Car(model, engine, cargo, tires.ToArray());
            return car;
        }
       
    }
}
