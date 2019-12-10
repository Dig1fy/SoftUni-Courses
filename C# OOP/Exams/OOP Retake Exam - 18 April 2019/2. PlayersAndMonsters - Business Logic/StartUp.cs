namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;
    using PlayersAndMonsters.Commands.Contracts;
    using PlayersAndMonsters.Commands;

    public class StartUp
    {
        public static void Main()
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();
            ICommandInterpreter commandInterpreter = new CommandInterpreter();

            ICardRepository cardRepository = new CardRepository();
            IPlayerRepository playerRepository = new PlayerRepository();
            IBattleField battleField = new BattleField();
            IPlayerFactory playerFactory = new PlayerFactory();
            ICardFactory cardFactory = new CardFactory();

            IManagerController managerController = new ManagerController(
                  cardRepository
                , playerRepository
                , battleField
                , cardFactory
                , playerFactory);

            var engine = new Engine(
                writer
                , reader
                , managerController
                , commandInterpreter);

            engine.Run();
        }
    }
}