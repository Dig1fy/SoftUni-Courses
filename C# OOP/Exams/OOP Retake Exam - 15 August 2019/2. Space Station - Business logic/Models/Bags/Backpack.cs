using System.Collections.Generic;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private List<string> backpackItems;

        public Backpack()
        {
            this.backpackItems = new List<string>();
        }
        public ICollection<string> Items => this.backpackItems;
    }
}
