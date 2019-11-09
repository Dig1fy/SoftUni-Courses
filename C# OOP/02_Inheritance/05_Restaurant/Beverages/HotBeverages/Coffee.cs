namespace Restaurant.Beverages.HotBeverages
{
    public class Coffee : HotBeverage
    {
        private const double COFFEE_MILLILITERS = 50;
        private const decimal COFFEE_PRICE = 3.50M;
        public Coffee(string name, double caffeine )
            : base (name, COFFEE_PRICE, COFFEE_MILLILITERS)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
