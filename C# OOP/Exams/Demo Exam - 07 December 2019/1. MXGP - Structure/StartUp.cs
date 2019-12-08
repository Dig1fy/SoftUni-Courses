namespace MXGP
{
    using MXGP.Core;
    using MXGP.Core.Contracts;
    using MXGP.IO;
    using MXGP.IO.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IChampionshipController controller = new ChampionshipController();

            var engine = new Engine(writer, reader, controller);

            engine.Run();
        }
    }
}