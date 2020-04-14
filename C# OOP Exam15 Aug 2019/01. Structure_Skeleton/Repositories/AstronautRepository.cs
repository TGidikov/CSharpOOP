using System;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> astronauts;
        
        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }
        
        public IReadOnlyCollection<IAstronaut> Models => this.astronauts.AsReadOnly();
        
        public void Add(IAstronaut model)
        {
            astronauts.Add(model);
        }
        
        public IAstronaut FindByName(string name)
        {
            var astronautFound = astronauts.FirstOrDefault(a => a.Name == name);
            return astronautFound;
        }

        public bool Remove(IAstronaut model) => astronauts.Remove(model);
       
       
        
    }


}
