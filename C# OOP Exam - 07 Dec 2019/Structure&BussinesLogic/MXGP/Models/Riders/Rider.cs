using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        private string name;
        private const int MIN_SYMBOLS = 5;
        
        public Rider(string name)
        {
            this.Name = name;
            
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value)|| value.Length<MIN_SYMBOLS)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                this.name = value;
            }
        }
        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle==null)
            {
                throw new ArgumentException("Motorcycle cannot be null.");
            }
            this.Motorcycle = motorcycle;

        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }
        

        public bool CanParticipate => this.Motorcycle!=null;


        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
