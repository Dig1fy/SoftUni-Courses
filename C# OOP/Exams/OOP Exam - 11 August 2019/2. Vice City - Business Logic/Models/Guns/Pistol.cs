namespace ViceCity.Models.Guns
{
    using System;

    public class Pistol : Gun
    {
        private const int ShootBullets = 1;
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        public Pistol(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets, ShootBullets)
        {
        }
    }
}