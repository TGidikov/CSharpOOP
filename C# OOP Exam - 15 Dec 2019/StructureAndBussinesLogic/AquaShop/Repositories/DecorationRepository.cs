using System.Linq;
using System.Collections.Generic;
using AquaShop.Repositories.Contracts;
using AquaShop.Models.Decorations.Contracts;


namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> decorations;
        public DecorationRepository()
        {
            this.decorations = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models =>this.decorations.AsReadOnly();

        public void Add(IDecoration model)
        {
            this.decorations.Add(model);
        }

        public bool Remove(IDecoration model) => this.decorations.Remove(model);
        
        public IDecoration FindByType(string type)
        {
            var decorationTarget = decorations.FirstOrDefault(d => d.GetType().Name == type);

            return decorationTarget;
        }

    }
}
