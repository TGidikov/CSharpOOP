namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_TRUCK =1.6;
        private const double REFUEL_LIMITATION =0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
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
                 base.FuelConsumption = value+FUEL_CONSUMPTION_TRUCK;
            }
        }
    
        public override void Refuel(double fuelAmount)
        {
            
                base.Refuel(fuelAmount);
            this.FuelQuantity -= REFUEL_LIMITATION * fuelAmount;

        }
    }   
}
