using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.guns.AsReadOnly();

        public void Add(IGun model)
        {
            if (model==null)
            {
                throw new ArgumentException("Cannot add null in Gun Repository");
            }
            guns.Add(model);
        }

        public IGun FindByName(string name)
        {
            var gun = this.guns.FirstOrDefault(g => g.Name == name);
            return gun;
        }

        public bool Remove(IGun model) => this.guns.Remove(model);
       
    }
}
