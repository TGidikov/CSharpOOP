using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {

            while (true)
            {
                var astronaut = astronauts.FirstOrDefault(a => a.CanBreath);
                if (astronaut == null)
                {
                    break;
                }
                while (planet.Items.Count != 0)
                {
                    string item = planet.Items.FirstOrDefault();
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);

                    if (astronaut.CanBreath == false)
                    {
                        break;
                    }
                }
                if (planet.Items.Count == 0)
                {
                    break;
                }

            }


        }























        //while (astronauts.Any(a=>a.CanBreath))
        //{
        //    foreach (var astronaut in astronauts.Where(a=>a.CanBreath))
        //    {
        //        foreach (var item in planet.Items)
        //        {
        //            if (astronaut.CanBreath)
        //            {
        //                astronaut.Bag.Items.Add(item);
        //                astronaut.Breath();                           
        //                planet.Items.Remove(item);
        //            }
        //        }
        //    }
        //
        //}

    }
}

