using System;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class  Vehicle:IDriveable,IRefuelable
    {
        private double fuelQuantity;

        protected Vehicle
            (double fuelQuantity, double fuelConsumption,double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            
        }

        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
             protected set
            {
                if (value > TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
                
            }
        }
        public virtual double FuelConsumption { get; protected set; }
        public double TankCapacity { get; private set; }
        bool IsFull = false;
        public virtual string Drive(double kilometers)
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
        public string DriveEmpty(double kilometers)
        {
            double fuelNeeded = kilometers *( this.FuelConsumption-1.4);
            if (this.FuelQuantity < fuelNeeded)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }
            else
            {
                this.FuelQuantity -= fuelNeeded;
            }
            

            return
                $"{this.GetType().Name} travelled {kilometers} km";
        }

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount<=0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }
            else if (this.FuelQuantity+fuelAmount>this.TankCapacity)
            {
                IsFull = true;
                throw new InvalidOperationException
                    ($"Cannot fit {fuelAmount} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += fuelAmount;
            }
           
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
