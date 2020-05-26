namespace WildFarm.Models.Animals
{
    public abstract class Mammal : Animal
    {
        private string name;
        private double weight;

     
        protected Mammal(string name, double weight,string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }
        public string LivingRegion { get; private set; }
    }
}
