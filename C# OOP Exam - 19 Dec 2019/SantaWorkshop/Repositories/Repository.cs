namespace SantaWorkshop.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    
    using Contracts;

    public abstract class Repository<T> : IRepository<T>
    {
        private List<T> models;

        public Repository()
        {
            this.models = new List<T>();
        }

        public IReadOnlyCollection<T> Models 
        {
            get 
            {
                return this.models;
            }
        }

        public void Add(T model)
        {
            this.models.Add(model);
        }

        public abstract T FindByName(string name);

        public bool Remove(T model)
        {
            if (this.models.Contains(model))
            {
                this.models.Remove(model);
                return true;
            }

            return false;
        }
    }
}
