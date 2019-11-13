namespace FoodShortage.Contracts
{
    public interface IBuyer
    {
        int Food { get; }
        public void BuyFood();

        string Name { get; }
        int Age { get; }
    }
}
