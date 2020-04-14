using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const double CUBIC_CENTIMETERS = 125;
        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower) : base(model, horsePower,CUBIC_CENTIMETERS)
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
                if (value < 50 || value >69)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                this.horsePower = value;
            }


        }
    }
}
