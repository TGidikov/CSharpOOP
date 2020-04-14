using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public Map()
        {
        }

        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = new List<IPlayer>();

            foreach (var player in players)
            {
                if (player.GetType().Name=="Terrorist")
                {
                    terrorists.Add(player);
                }
            }

            var counterTerroris = new List<IPlayer>();

            foreach (var player in players)
            {
                if (player.GetType().Name=="CounterTerrorist")
                {
                    counterTerroris.Add(player);
                }
            }

            while (terrorists.Any(t => t.Health>0) || counterTerroris.Any(c => c.Health>0))
            {

                foreach (var terrorist in terrorists)
                {
                    if (terrorist.Health>0)
                    {
                        foreach (var counterT in counterTerroris)
                        {
                            if (counterT.IsAlive)
                            {
                                counterT.TakeDamage(terrorist.Gun.Fire());
                            }
                        }
                    }
                   
                }

                foreach (var counterT in counterTerroris)
                {
                    if (counterT.Health > 0)
                    {
                        foreach (var terrorist in terrorists)
                        {
                            if (terrorist.IsAlive)
                            {
                                terrorist.TakeDamage(counterT.Gun.Fire());
                            }

                        }
                    }
                   
                }

            }
            var terroristsWin = counterTerroris.FirstOrDefault(t => t.IsAlive);
            if (terrorists != null)
            {
                return "Terrorist wins!";
            }
            else
            {
                return "Counter Terrorist wins!";
            }


        }
       
    }
}

