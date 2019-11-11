namespace Ferrari
{
    public class Engine
    {
        public void Run()
        {
            var driverName = Reader.ReadLine();
            var driver = new Ferrari(driverName);
            Writer.Write($"{driver.Model}{driver.Brakes()}{driver.Gas()}{driver.Name}");
        }
    }
}
