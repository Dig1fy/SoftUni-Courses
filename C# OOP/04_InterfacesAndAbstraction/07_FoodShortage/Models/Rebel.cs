namespace FoodShortage.Models
{
    using Contracts;
    using FoodShortage.Enum;

    public class Rebel : IRebel, IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }
        public string Group { get; private set; }

        public int Food { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public void BuyFood()
        {
            this.Food += (int)State.Rebel;
        }
    }
}
