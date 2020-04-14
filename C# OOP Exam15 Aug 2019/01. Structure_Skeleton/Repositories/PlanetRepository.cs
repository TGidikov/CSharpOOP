using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<Planet>
    {
        private readonly List<Planet> planets;
        public PlanetRepository()
        {
            this.planets = new List<Planet>();
        }

        public IReadOnlyCollection<Planet> Models => this.planets.AsReadOnly();

        public void Add(Planet model)
        {
            planets.Add(model);
        }

        public Planet FindByName(string name)
        {
            return planets.First(p => p.Name == name);
        }

        public bool Remove(Planet model) => planets.Remove(model);
       
    }
}
