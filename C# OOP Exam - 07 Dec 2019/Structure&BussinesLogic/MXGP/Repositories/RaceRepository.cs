using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;
        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public ICollection<IRace> Models => this.races;
       
        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            var racesCollection = this.races.AsReadOnly();
            return racesCollection;
        }

        public IRace GetByName(string name)
        {
            var target = races.FirstOrDefault(r => r.Name == name);
            return target;
        }

        public bool Remove(IRace model) => this.races.Remove(model);
        
    }
}
