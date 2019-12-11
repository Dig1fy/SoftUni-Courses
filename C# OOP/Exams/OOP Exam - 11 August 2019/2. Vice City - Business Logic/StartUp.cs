namespace ViceCity
{
    using ViceCity.Core;
    using ViceCity.Core.Contracts;
    using ViceCity.Models.Neghbourhoods;
    using ViceCity.Models.Neghbourhoods.Contracts;
    using ViceCity.Models.Players;
    using ViceCity.Models.Players.Contracts;

    public class StartUp
    {
        IEngine engine;
        static void Main(string[] args)
        {
            IPlayer mainPlayer = new MainPlayer();
            INeighbourhood neighbourhood = new GangNeighbourhood();
            IController controller = new Controller(mainPlayer, neighbourhood);

            IEngine engine = new Engine(controller);
            engine.Run();
        }
    }
}
