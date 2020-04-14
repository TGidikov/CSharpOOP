using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine,ITank
    {
        private const double INITIAL_HEALTH = 200;
        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints,INITIAL_HEALTH )
        {
            ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode == false)
            {
                this.DefenseMode = true;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else  
            {
                DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            
        }
        public override string ToString()
        {
            var mode = this.DefenseMode == true ? "ON" : "OFF";
            return base.ToString() + $" *Aggressive: {mode}";


        }
    }
}
