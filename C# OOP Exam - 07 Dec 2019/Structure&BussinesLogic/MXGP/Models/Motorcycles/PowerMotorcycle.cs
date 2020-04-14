using MXGP.Models.Motorcycles;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const double CUBIC_CENTIMETERS = 450;
        private int horsePower;

        public PowerMotorcycle(string model, int horsePower) : base(model, horsePower,CUBIC_CENTIMETERS)
        {

        }
        public override int HorsePower
        {
            get 
            {
                return this.horsePower;
            }
            protected set
            {
                if (value>100 || value<70)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                this.horsePower = value;
            }
               

        }
    }
}
