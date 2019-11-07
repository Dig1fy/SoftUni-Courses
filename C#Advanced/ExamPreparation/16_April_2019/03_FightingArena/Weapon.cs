namespace FightingArena
{
   public class Weapon
    {
        public Weapon(int size, int solidity, int sharpness)
        {
            Size = size;
            Solidity = solidity;
            Sharpness = sharpness;
        }

        public int Size { get; set; }
        public int Solidity { get; set; }
        public int Sharpness { get; set; }
    }
}
