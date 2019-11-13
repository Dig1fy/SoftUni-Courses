namespace FoodShortage.Models
{
    using Contracts;
    using FoodShortage.Enum;

    public class Citizen : ICitizen, IBuyer
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Food = 0;
        }
        public string Id { get; private set; }


        public int Food { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public void BuyFood()
        {
            this.Food += (int)State.Citizen;
        }
    }
}
