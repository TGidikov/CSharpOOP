using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Races
{
    public class Race : IRace
    {
        private const int MIN_SYMBOLS = 5;
        private string name;
        private int laps;
        private readonly List<IRider> riders;

        public Race(string name,int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.riders = new List<IRider>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MIN_SYMBOLS)
                {
                    throw new ArgumentException($"Name {this.Name} cannot be less than 5 symbols.");
                }
                this.name = value;

            }
        }


        public int Laps
        {
            get
            {
                return this.laps;
            }
            private set
            {
                if (value<1)
                {
                    throw new ArgumentException("Laps cannot be less than 1.");
                }
                this.laps = value;

            }
        }

        public IReadOnlyCollection<IRider> Riders => riders.AsReadOnly();

        public void AddRider(IRider rider)
        {
            if (rider==null)
            {
                throw new ArgumentException("Rider cannot be null.");
            }
            else if (!rider.CanParticipate)
            {
                throw new ArgumentException($"Rider {rider.Name} could not participate in race.");
            }
            else if (riders.Contains(rider))
            {
                throw new ArgumentNullException($"Rider {rider.Name} is already added in {this.Name} race.");
            }
            else
            {
                riders.Add(rider);
            }

        }
    }
}
