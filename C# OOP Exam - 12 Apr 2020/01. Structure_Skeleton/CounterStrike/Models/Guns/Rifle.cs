using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int BULLETS_FIRED = 10;
        public Rifle(string name, int bulletsCount) : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {

            int firedBullets = 0;
            if (this.BulletsCount - BULLETS_FIRED >= 0)
            {
                this.BulletsCount -= BULLETS_FIRED;
                firedBullets = BULLETS_FIRED;
            }
           

            return firedBullets;

        }
    }
}
