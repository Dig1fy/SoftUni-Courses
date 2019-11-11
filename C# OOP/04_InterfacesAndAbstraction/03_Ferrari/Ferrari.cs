namespace Ferrari
{
    public class Ferrari : IDrive
    {
        private const string MODEL = "488-Spider";
        public Ferrari(string driver)
        {
            this.Name = driver;
        }
        public string Name { get; set; }

        public string Model => MODEL;
        public string Brakes()
        {
          return "/Brakes!/";
        }

        public string Gas()
        {
            return "Gas!/";
        }
    }
}
