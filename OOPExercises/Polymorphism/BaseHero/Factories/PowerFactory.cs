using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
    public class PowerFactory
    {

        public int AddPower(BaseHero hero)
        {
            int totalPower = 0;
            
            if (hero is Druid )
            {
                totalPower = 80;
            }
            else if (hero is Paladin)
            {
                totalPower = 100;
            }
            else if (hero is Rogue)
            {
                totalPower = 80;
            }
            else if (hero is Warrior)
            {
                totalPower = 100;
            }

            return totalPower;

        }
    }
}
