namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int ShootBullets = 5;
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        public Rifle(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets, ShootBullets)
        {
        }
    }
}