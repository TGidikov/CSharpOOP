using System.Linq;
using System.Collections.Generic;
using MXGP.Repositories.Contracts;
using MXGP.Models.Riders.Contracts;


namespace MXGP.Repositories
{
    public class RiderRepository : IRepository<IRider>
    {
        private readonly List<IRider> riders;
        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }
        public ICollection<IRider> Models => this.riders;

        public void Add(IRider model)
        {
            this.riders.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            var ridersCollection = this.riders.AsReadOnly();
            return ridersCollection;
        }

        public IRider GetByName(string name)
        {
           var rider =this.Models.FirstOrDefault(r => r.Name == name);
            return rider;
        }

        public bool Remove(IRider model) => this.Models.Remove(model);
            
       
    }
}
