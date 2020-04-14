using System;
using System.Text;
using System.Collections.Generic;
using ViceCity.Models.Players.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using System.Linq;

namespace ViceCity.Models.Neghbourhoods
{
    public class Neighbourhood : INeighbourhood
    {
        public Neighbourhood()
        {

        }

        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {

            foreach (var gun in mainPlayer.GunRepository.Models)
            {
                foreach (var currentCivilPlayer in civilPlayers)
                {
                    while (currentCivilPlayer.IsAlive && gun.CanFire)
                    {
                        currentCivilPlayer.TakeLifePoints(gun.Fire());
                    }
                    if (!gun.CanFire)
                    {
                        break;
                    }
                }
               
            }
            foreach (var currenCivil in civilPlayers.Where(p=>p.IsAlive))
            {
                foreach (var gun in currenCivil.GunRepository.Models)
                {
                    while (mainPlayer.IsAlive && gun.CanFire)
                    {
                        mainPlayer.TakeLifePoints(gun.Fire());
                    }
                    if (!mainPlayer.IsAlive)
                    {
                        break;
                    }
                }
                if (!mainPlayer.IsAlive)
                {
                    break;
                }

            }
            


        }

    }
}
