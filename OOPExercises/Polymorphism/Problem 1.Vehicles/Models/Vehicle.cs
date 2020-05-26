using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class  Vehicle:IDriveable,IRefuelable
    {
        public Vehicle(double fuelQunatity,double fuelConsumption)
        {
            this.FuelQuantity = fuelQunatity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; private set; }
        public virtual double FuelConsumption { get; protected set; }
       
        public string Drive(double kilometers)
        {
            double fuelNeeded = kilometers * this.FuelConsumption;
            if (this.FuelQuantity<fuelNeeded)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }
            this.FuelQuantity -= fuelNeeded;
            return
                $"{this.GetType().Name} travelled {kilometers} km";
        }

        public virtual void Refuel(double fuelAmount)
        {
            this.FuelQuantity += fuelAmount;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
