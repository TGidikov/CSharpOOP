using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {

        private readonly List<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }

        public ICollection<IMotorcycle> Models => this.motorcycles;

        public void Add(IMotorcycle model)
        {
            this.motorcycles.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            var motorcyclesCollection = this.motorcycles.AsReadOnly();
            return motorcycles;
        }

        public IMotorcycle GetByName(string name)
        {
            var target = motorcycles.FirstOrDefault(m => m.Model == name);
            return target;
        }

        public bool Remove(IMotorcycle model) => motorcycles.Remove(model);

    }
}
