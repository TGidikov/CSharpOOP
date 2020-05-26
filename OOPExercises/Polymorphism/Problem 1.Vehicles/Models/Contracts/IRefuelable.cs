using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models.Contracts
{
    interface IRefuelable
    {
        void Refuel(double fuelAmount);
    }
}
