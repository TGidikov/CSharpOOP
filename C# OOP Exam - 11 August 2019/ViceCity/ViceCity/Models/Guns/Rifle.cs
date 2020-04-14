using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
   public class Rifle:Gun
    {
        private const int BULLETS_PER_BARREL = 50;
        private const int TOTAL_BULLETS = 500;
        private const int BULLETS_PER_FIRE = 5;
        public Rifle(string name) : base(name, BULLETS_PER_BARREL, TOTAL_BULLETS)
        {
        }

        public override int Fire()
        {
            if (BulletsPerBarrel < BULLETS_PER_FIRE)
            {
                this.Reload(BULLETS_PER_BARREL);

            }
            int firedBullets = this.DecreaseBullets(BULLETS_PER_FIRE);
            return firedBullets;
        }
    }
}
