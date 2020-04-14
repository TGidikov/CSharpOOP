namespace SantaWorkshop.Models.Dwarfs
{
    using System;
    using System.Collections.Generic;

    using Dwarfs.Contracts;
    using Instruments.Contracts;
    using SantaWorkshop.Utilities.Messages;

    public abstract class Dwarf : IDwarf
    {
        private string name;
        private int energy;

        public Dwarf(string name, int energy)
        {
            this.Name = name;
            this.Energy = energy;
            this.Instruments = new List<IInstrument>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDwarfName);
                }

                this.name = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            protected set
            {
                if (value < 0)
                {
                    this.energy = 0;
                }
                else
                {
                    this.energy = value;
                }
            }
        }

        public ICollection<IInstrument> Instruments { get; }

        public void AddInstrument(IInstrument instrument)
        {
            this.Instruments.Add(instrument);
        }

        public virtual void Work() 
        {
            this.Energy -= 10;

            if (this.Energy < 0)
            {
                this.Energy = 0;
            }
        }
    }
}
