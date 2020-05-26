namespace Raiding
{
    public abstract class BaseHero
    {
        protected  BaseHero(string name)
        {
            this.Name = name;
           
        }
        protected string  Name { get; private set; }
        public abstract int Power { get; }

        public abstract string CastAbility();

    }
}
