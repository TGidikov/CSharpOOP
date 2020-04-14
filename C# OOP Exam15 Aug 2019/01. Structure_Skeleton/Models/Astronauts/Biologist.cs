using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double UNITS_OF_OXYGEN= 70;
        public Biologist(string name) : base(name, UNITS_OF_OXYGEN)
        {
        }

        public override void Breath()
        {
            if (this.Oxygen - 5 > 0)
            {
                Oxygen = -5;
            }
            Oxygen = 0;
        }
    }
}
