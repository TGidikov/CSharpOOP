using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;

namespace Vehicles.Factories
{
    public class VehicleFactory
    {
        public Vehicle ProduceVahicle(string type,double fuelQty,
            double fuelConsumption,double tankCapacity)
        {
            Vehicle vehicle=null;
            if (type=="Car")
            {
                vehicle = new Car(fuelQty, fuelConsumption,tankCapacity);
            }
            else if(type=="Truck")
            {
                vehicle = new Truck(fuelQty, fuelConsumption,tankCapacity);
            }
            else if(type=="Bus")
            {
                vehicle = new Bus(fuelQty, fuelConsumption, tankCapacity);
            }
            if (vehicle==null)
            {
                throw new ArgumentException("Invalide vehicle type!");
            }
            return vehicle;
        }

    }
}
