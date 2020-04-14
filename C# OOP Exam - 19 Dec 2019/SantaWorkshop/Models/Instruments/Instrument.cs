
namespace SantaWorkshop.Models.Instruments
{
    using Instruments.Contracts;

    public class Instrument : IInstrument
    {
        private int power;

        public Instrument(int power)
        {
            this.Power = power;
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            private set
            {
                if (value < 0)
                {
                    this.power = 0;
                }
                else
                {
                    this.power = value;
                }
            }
        }

        public bool IsBroken()
        {
            if (this.Power == 0)
            {
                return true;
            }

            return false;
        }

        public void Use()
        {
            if (this.Power - 10 > 0)
            {
                this.Power -= 10;
            }
            else 
            {
                this.Power = 0;
            }
        }
    }
}
