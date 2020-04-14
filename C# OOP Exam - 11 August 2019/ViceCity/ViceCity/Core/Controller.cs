using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private readonly IPlayer mainPlayer;
        private readonly ICollection<IPlayer> civilPlayers;
        private readonly ICollection<IGun> guns;
        private readonly INeighbourhood neighbourhood;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();
            this.guns = new List<IGun>();
            this.neighbourhood = new Neighbourhood();
        }
        public string AddPlayer(string name)
        {

            var civilPlayer = new CivilPlayer(name);
            civilPlayers.Add(civilPlayer);
            return $"Successfully added civil player: {name}!";
        }

        public string AddGun(string type, string name)
        {


            if (nameof(Pistol) == type)
            {
                guns.Add(new Pistol(name));
            }
            else if (nameof(Rifle) == type)
            {
                guns.Add(new Rifle(name));
            }
            else
            {
                return "Invalid gun type!";
            }

            return $"Successfully added {name} of type: {type}";
        }




        public string AddGunToPlayer(string name)
        {

            if (this.guns.Count == 0)
            {
                return "There are no guns in the queue!";
            }
            IGun gun = this.guns.FirstOrDefault();
            var civilPlayer = this.civilPlayers.FirstOrDefault(p => p.Name == name);
            var message = string.Empty;
            if (name == "Vercetti")
            {
                mainPlayer.GunRepository.Add(gun);
                message= $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }
            else if (civilPlayer != null)
            {
                civilPlayer.GunRepository.Add(gun);
                message= $"Successfully added {gun.Name} to the Civil Player: {civilPlayer.Name}";
            }
            else
            {

                return $"Civil player with that name doesn't exists!";
            }
            this.guns.Remove(gun);
            return message;
       

        } 
       
       
        public string Fight()
        {
            var civilTotalLife = civilPlayers.Sum(c => c.LifePoints);
            neighbourhood.Action(mainPlayer, civilPlayers);
            
            //if (civilPlayers.Any(c=>!c.IsAlive))
            //{
            //    var deadPlayer = civilPlayers.First(c => !c.IsAlive);
            //    civilPlayers.Remove(deadPlayer);
            //}
            var sumCivilAfterFight = civilPlayers.Sum(c => c.LifePoints);
            
            if (mainPlayer.LifePoints == 100 && civilTotalLife==sumCivilAfterFight)
            {
                return "Everything is okay!";
            }
            else
            {
                var sb = new StringBuilder();


                var deadCivilPlayers = civilPlayers.Where(c => !c.IsAlive).Count();
                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {deadCivilPlayers} players!");
                sb.AppendLine($"Left Civil Players: {civilPlayers.Where(c=>c.IsAlive).Count()}!");

                return sb.ToString().TrimEnd();
            }
        }
    }
}
