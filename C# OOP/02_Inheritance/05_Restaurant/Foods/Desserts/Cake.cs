
namespace Restaurant.Foods.Desserts
{
    class Cake : Dessert
    {
        private const double GRAMS = 250;
        private const double CALORIES = 1000;
        private const decimal PRICE = 5;
        public Cake(string name )
            : base (name, PRICE, GRAMS, CALORIES)
        {
        }
    }
}
