
namespace SantaWorkshop.Repositories
{
    using System.Linq;

    using Models.Presents.Contracts;

    public class PresentRepository : Repository<IPresent>
    {
        public override IPresent FindByName(string name)
        {
            var present = this.Models.First(m => m.Name == name);
            return present;
        }
    }
}
