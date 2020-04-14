
namespace SantaWorkshop.Repositories
{
    using System.Linq;

    using Models.Dwarfs.Contracts;

    public class DwarfRepository : Repository<IDwarf>
    {
        public override IDwarf FindByName(string name)
        {
            var dwarf = this.Models.First(m => m.Name == name);
            return dwarf;
        }
    }
}
