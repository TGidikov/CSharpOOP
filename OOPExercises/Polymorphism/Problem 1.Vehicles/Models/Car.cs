using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double FUEL_CONSUMPTION_CAR = 0.9;
        public Car(double fuelQunatity, double fuelConsumption)
            : base(fuelQunatity, fuelConsumption)
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
                base.FuelConsumption = value + FUEL_CONSUMPTION_CAR;
            }

        }
    }
}
