using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double INITIAL_HEALTH = 200;
        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints,INITIAL_HEALTH)
        {
            this.ToggleAggressiveMode();
        }

        public bool AggressiveMode { get; private set; }

       

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode==false)
            {
                AggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else      
            {
                AggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;

            }
  
        }
        public override string ToString()
        {
            var agresiveMode = this.AggressiveMode == true ? "ON" : "OFF";
            return base.ToString() + $" *Aggressive: {agresiveMode}";
            
        }
    }
}
