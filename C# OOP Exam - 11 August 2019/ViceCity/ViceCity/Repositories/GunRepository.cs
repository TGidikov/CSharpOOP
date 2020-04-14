using System;
using System.Collections.Generic;
using System.Linq;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> guns;

        public GunRepository()
        {
            this.guns= new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.guns.AsReadOnly();

        public void Add(IGun model)
        {
            if (!guns.Contains(model))
            {
                guns.Add(model);
            }
        }

        public IGun Find(string name)
        {
            var gun = guns.First(g => g.Name == name);
            return gun;
        }

        public bool Remove(IGun model) => guns.Remove(model);
       
    }
}
