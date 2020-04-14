namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int INITIAL_ENERGY = 50;

        public SleepyDwarf(string name) 
            : base(name, INITIAL_ENERGY)
        {

        }

       public override void Work()
       {
           this.Energy -= 15;
       
           if (this.Energy < 0)
           {
               this.Energy = 0;
           }
       }
    }
}
