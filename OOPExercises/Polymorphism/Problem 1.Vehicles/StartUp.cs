using System;
using Vehicles.Core;
using Vehicles.Core.Contracts;

namespace Vehicles

{
    class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();

        }
    }
}