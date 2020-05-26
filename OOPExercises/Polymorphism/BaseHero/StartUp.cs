using Raiding.Core;
using Raiding.Core.Contracts;

namespace BaseHero
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
