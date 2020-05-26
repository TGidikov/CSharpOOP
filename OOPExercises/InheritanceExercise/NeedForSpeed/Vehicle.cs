namespace NeedForSpeed
{
    public class Vehicle
    {
        private int horsePower;
        private double fuel;
        private const double  DefaultFuelConsumption= 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public Vehicle()
        {
        }

        public virtual double FuelConsumption => DefaultFuelConsumption;

        public double Fuel
        {
            get
            {
                return this.fuel;
            }
            set
            {
                this.fuel = value;
            }
        }
        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            set
            {
                this.horsePower = value;
            }
        }

        public virtual void Drive(double kilometres)
        {
            bool canDrive = this.fuel - kilometres *this.FuelConsumption>=0;

            if (canDrive)
            {
                this.fuel -= kilometres * FuelConsumption;
            }
           
        }
    }
}
