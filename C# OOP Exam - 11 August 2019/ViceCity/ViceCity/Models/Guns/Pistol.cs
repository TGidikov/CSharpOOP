using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int BULLETS_PER_BARREL = 10;
        private const int TOTAL_BULLETS = 100;
        private const int BULLETS_PER_FIRE = 1;
        public Pistol(string name) : base(name, BULLETS_PER_BARREL, TOTAL_BULLETS)
        {
        }

        public override int Fire()
        {
            if (BulletsPerBarrel<BULLETS_PER_FIRE)
            {
                this.Reload(BULLETS_PER_BARREL);
                
            }
            int firedBullets = this.DecreaseBullets(BULLETS_PER_FIRE);
            return firedBullets;
        }
       
    }
   
}
