namespace ViceCity
{
    using ViceCity.Core;
    using ViceCity.Core.Contracts;

    public class StartUp
    {
        IEngine engine;
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
