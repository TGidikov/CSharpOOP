using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;
        private List<IPlayer> alivePlayers;
        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            if (type=="Pistol")
            {
                guns.Add(new Pistol(name, bulletsCount));
                return $"Successfully added gun {name}.";
            }
            else if (type=="Rifle")
            {
                guns.Add(new Rifle(name, bulletsCount));
                return $"Successfully added gun {name}.";
            }
            else
            {
                return "Invalid gun type.";
            }

        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var message = string.Empty;
            var gun = guns.FindByName(gunName);
            if (gun==null)
            {
                throw new ArgumentException("Gun cannot be found!");
            }

            if (type=="Terrorist")
            {
                players.Add(new Terrorist(username, health, armor, gun));
                message = $"Successfully added player {username}.";
            }
            else if (type== "CounterTerrorist")
            {
                players.Add(new CounterTerrorist(username, health, armor, gun));
                message = $"Successfully added player {username}.";
            }
            else
            {
                throw new ArgumentException("Invalid player type!");
            }
            return message;

        }
        public string StartGame()
        {
           

            var result = map.Start(players.Models.Where(p => p.IsAlive).ToList());
            return result;
           
        }

        public string Report()
        {
            var collection = players.Models
                .OrderBy(p => p.GetType().Name)
                .ThenByDescending(p => p.Health)
                .ThenBy(p => p.Username);
            var sb = new StringBuilder();
            foreach (var player in collection)
            {
                sb.AppendLine($"{player.GetType().Name}: {player.Username}");
                sb.AppendLine($"--Health: {player.Health}");
                sb.AppendLine($"--Armor: {player.Armor}");
                sb.AppendLine($"--Gun: {player.Gun.Name}");
                sb.AppendLine();

            }
            return sb.ToString().TrimEnd();
        }

    }
}
