using System;
using System.Linq;
using Vehicles.Core.Contracts;
using Vehicles.Factories;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private VehicleFactory vehichleFactory;
        public Engine()
        {
            this.vehichleFactory = new VehicleFactory();
        }
        public void Run()
        {
           Vehicle car= ProduceVehicle();
            Vehicle truck = ProduceVehicle();
            Vehicle bus = ProduceVehicle();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var commandInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var command = commandInput[0];
                var typeVehicle = commandInput[1];
                var distanceOrLitres = double.Parse(commandInput[2]);
                try
                {
                    if (command == "Drive")
                    {
                        if (typeVehicle == "Car")
                        {
                            Console.WriteLine(car.Drive(distanceOrLitres)); 
                        }
                        else if (typeVehicle == "Truck")
                        {
                            Console.WriteLine(truck.Drive(distanceOrLitres));
                        }
                        else if (typeVehicle == "Bus")
                        {
                            Console.WriteLine(bus.Drive(distanceOrLitres));
                        }
                    }
                   
                    else if (command == "Refuel")
                    {
                        if (typeVehicle == "Car")
                        {
                            car.Refuel(distanceOrLitres);
                        }
                        else if (typeVehicle == "Truck")
                        {
                            truck.Refuel(distanceOrLitres);
                        }
                        else if(typeVehicle=="Bus")
                        {
                            bus.Refuel(distanceOrLitres);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        Console.WriteLine(bus.DriveEmpty(distanceOrLitres));
                    }


                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine(ex.Message);
                }
              

            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private Vehicle ProduceVehicle()
        {
            var VehicleInput = Console.ReadLine()
                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                           .ToArray();
            var type = VehicleInput[0];
            var fuelQty = double.Parse(VehicleInput[1]);
            var fuelConsumption = double.Parse(VehicleInput[2]);
            var tankCapacity = double.Parse(VehicleInput[3]);
            Vehicle vehicle = this.vehichleFactory
                .ProduceVahicle(type, fuelQty, fuelConsumption,tankCapacity);
            return vehicle;
        }


    }
}

