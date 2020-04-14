using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly List<IPlayer> players;
        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => players.AsReadOnly();

        public void Add(IPlayer model)
        {
            if (model==null)
            {
                throw new ArgumentException("Cannot add null in Player Repository");

            }
            this.players.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            var player = this.players.FirstOrDefault(p => p.Username == name);
            return player;
        }

        public bool Remove(IPlayer model) => this.players.Remove(model);
       
    }
}
