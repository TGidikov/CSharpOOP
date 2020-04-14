using MXGP.Models.Motorcycles.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {
        private int horsePower;
        private string model;

        private const int MIN_SYMBOLS = 4;
        public Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model

        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }
                this.model = value;
            }
        }

        public virtual int HorsePower
        {
           get
           {
               return this.horsePower;
           }
           protected set
           {
               if (value<0)
               {
                   new ArgumentException($"Invalid horse power: {value}.");
               }
               this.horsePower = value;
           
           }
        }


        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            var result= this.CubicCentimeters / this.HorsePower * laps;
            return result;
        }
    }
}
