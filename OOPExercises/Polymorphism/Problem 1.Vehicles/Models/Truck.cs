using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_TRUCK =1.6;
        private const double REFUEL_LIMITATION =0.95;
        public Truck(double fuelQunatity,double fuelConsumption) 
          : base(fuelQunatity,fuelConsumption)
        {

        }
        public override double FuelConsumption 
        {
            get
            {
                return base.FuelConsumption;
            }
            protected set
            {
                 base.FuelConsumption = value+FUEL_CONSUMPTION_TRUCK;
            }
        }
        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount*REFUEL_LIMITATION);
        }
    }
}
