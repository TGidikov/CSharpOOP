
namespace SantaWorkshop.Models.Presents
{
    using System;

    using Presents.Contracts;
    using Utilities.Messages;

    public class Present : IPresent
    {
        private string name;
        private int energyRequired;

        public Present(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
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
                    throw new ArgumentException(ExceptionMessages.InvalidPresentName);
                }

                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get
            {
                return this.energyRequired;
            }
            private set
            {
                if (value < 0)
                {
                    this.energyRequired = 0;
                }
                else
                {
                    this.energyRequired = value;
                }
            }
        }

        public void GetCrafted()
        {
            if (this.EnergyRequired - 10 > 0)
            {
                this.EnergyRequired -= 10;
            }
            else 
            {
                this.EnergyRequired = 0;
            }
        }

        public bool IsDone()
        {
            if (this.EnergyRequired == 0)
            {
                return true;
            }

            return false;
        }
    }
}
